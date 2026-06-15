using Steamworks;
using Unity.Netcode;
using UnityEngine;

public class NWK_Inviter : NetworkBehaviour
{
    public void HostLobby()
    {
        //NetworkManager.Singleton.StartHost();
       // SteamMatchmaking.CreateLobbyAsync(100);
        SteamManager.Instance.CreateLobby(22);
    }
}
