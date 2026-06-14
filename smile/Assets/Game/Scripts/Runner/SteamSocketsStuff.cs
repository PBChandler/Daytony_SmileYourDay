using Steamworks;
using Netcode;
using UnityEngine;
using Steamworks.ServerList;
using Steamworks.Ugc;
using Steamworks.Data;
using Valve.Sockets;

using System;
using Unity.Netcode;
using System.Linq;
using Unity.Collections;
// Code for SteamNetworkingSockets which replaced SteamNetworking P2P code SteamManager

// SOCKET CLASS that creates socket server, only host of each match utilizes this
public class SteamSocketManager : SocketManager
{
    public override void OnConnecting(Connection connection, Steamworks.Data.ConnectionInfo data)
    {
        base.OnConnecting(connection, data);//The base class will accept the connection
        Debug.Log("SocketManager OnConnecting");
    }

    public override void OnConnected(Connection connection, Steamworks.Data.ConnectionInfo data)
    {
        base.OnConnected(connection, data);
        Debug.Log("New player connecting");
    }

    public override void OnDisconnected(Connection connection, Steamworks.Data.ConnectionInfo data)
    {
        base.OnDisconnected(connection, data);
        Debug.Log("Player disconnected");
    }

    public override void OnMessage(Connection connection, NetIdentity identity, IntPtr data, int size, long messageNum, long recvTime, int channel)
    {
        // Socket server received message, forward on message to all members of socket server
       
        //SteamManager.Instance.RelaySocketMessageReceived(data, size, connection.Id);
        SteamManager.Instance.ProcessMessageFromSocketServer(data, size);
        Debug.Log("Socket message received");
    }
}

// CONNECTION MANAGER that enables all players to connect to Socket ServerW
public class SteamConnectionManager : ConnectionManager
{
    public SteamId PlayerSteamId, OpponentSteamId;
    public SteamSocketManager steamSocketManager;
    public SteamConnectionManager steamConnectionManager;
    public override void OnConnected(Steamworks.Data.ConnectionInfo info)
    {
        base.OnConnected(info);
        Debug.Log("ConnectionOnConnected");
    }

    public override void OnConnecting(Steamworks.Data.ConnectionInfo info)
    {
        base.OnConnecting(info);
        Debug.Log("ConnectionOnConnecting");
    }

    public override void OnDisconnected(Steamworks.Data.ConnectionInfo info)
    {
        base.OnDisconnected(info);
        Debug.Log("ConnectionOnDisconnected");
    }

    public override void OnMessage(IntPtr data, int size, long messageNum, long recvTime, int channel)
    {
        // Message received from socket server, delegate to method for processing
        SteamManager.Instance.ProcessMessageFromSocketServer(data, size);
        Debug.Log("Connection Got A Message");
    }


    // SteamManager.cs code/ methods that facilitate sending and receiving messages to and from Socket server

    public void Awake()
    {
        // Helpful to reduce time to use SteamNetworkingSockets later
        SteamNetworkingUtils.InitRelayNetworkAccess();
    }

    public bool activeSteamSocketServer;
    public bool activeSteamSocketConnection;

    void Update()
    {
        SteamClient.RunCallbacks();
        try
        {
            if (activeSteamSocketServer)
            {
                steamSocketManager.Receive();
            }
            if (activeSteamSocketConnection)
            {
                steamConnectionManager.Receive();
            }
        }
        catch
        {
            Debug.Log("Error receiving data on socket/connection");
        }
    }

    private void CreateSteamSocketServer()
    {
        steamSocketManager = SteamNetworkingSockets.CreateRelaySocket<SteamSocketManager>(0);
        // Host needs to connect to own socket server with a ConnectionManager to send/receive messages
        // Relay Socket servers are created/connected to through SteamIds rather than "Normal" Socket Servers which take IP addresses
        steamConnectionManager = SteamNetworkingSockets.ConnectRelay<SteamConnectionManager>(PlayerSteamId);
        activeSteamSocketServer = true;
        activeSteamSocketConnection = true;
    }

    private void JoinSteamSocketServer()
    {
        bool NOT_HOST = !NetworkManager.Singleton.IsHost;
        if (NOT_HOST)
        {
            Debug.Log("joining socket server");
            steamConnectionManager = SteamNetworkingSockets.ConnectRelay<SteamConnectionManager>(OpponentSteamId, 0);
            activeSteamSocketServer = false;
            activeSteamSocketConnection = true;
        }
    }

    private void LeaveSteamSocketServer()
    {
        activeSteamSocketServer = false;
        activeSteamSocketConnection = false;
        try
        {
            // Shutdown connections/sockets. I put this in try block because if player 2 is leaving they don't have a socketManager to close, only connection
            steamConnectionManager.Close();
            steamSocketManager.Close();
        }
        catch
        {
            Debug.Log("Error closing socket server / connection manager");
        }
    }

    public void RelaySocketMessageReceived(IntPtr message, int size, uint connectionSendingMessageId)
    {
        try
        {
            // Loop to only send messages to socket server members who are not the one that sent the message
            for (int i = 0; i < steamSocketManager.Connected.Count; i++)
            {
                if (steamSocketManager.Connected.ElementAt(i).Id == connectionSendingMessageId)
                {
                    Steamworks.Result success = steamSocketManager.Connected.ElementAt(i).SendMessage(message, size); 
                    if (success !=  Steamworks.Result.OK)
                    {
                         Steamworks.Result retry = steamSocketManager.Connected.ElementAt(i).SendMessage(message, size); 
                    }
                }
            }
        }
        catch
        {
            Debug.Log("Unable to relay socket server message");
        }
    }

    public bool SendMessageToSocketServer(byte[] messageToSend)
    {
        try
        {
            // Convert string/byte[] message into IntPtr data type for efficient message send / garbage management
            int sizeOfMessage = messageToSend.Length;
            IntPtr intPtrMessage = System.Runtime.InteropServices.Marshal.AllocHGlobal(sizeOfMessage);
            System.Runtime.InteropServices.Marshal.Copy(messageToSend, 0, intPtrMessage, sizeOfMessage);
            Steamworks.Result success = steamConnectionManager.Connection.SendMessage(intPtrMessage, sizeOfMessage, SendType.Reliable);
            if (success == Steamworks.Result.OK)
            {
                System.Runtime.InteropServices.Marshal.FreeHGlobal(intPtrMessage); // Free up memory at pointer
                return true;
            }
            else
            {
                // RETRY
                Steamworks.Result retry = steamConnectionManager.Connection.SendMessage(intPtrMessage, sizeOfMessage, SendType.Reliable);
                System.Runtime.InteropServices.Marshal.FreeHGlobal(intPtrMessage); // Free up memory at pointer
                if (retry == Steamworks.Result.OK)
                {
                    return true;
                }
                return false;
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            Debug.Log("Unable to send message to socket server");
            return false;
        }
    }

    
}