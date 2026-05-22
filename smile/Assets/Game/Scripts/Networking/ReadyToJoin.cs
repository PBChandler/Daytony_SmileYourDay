using Steamworks;
using Steamworks.Data;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;
public class ReadyToJoin : MonoBehaviour
{
    public UnityEvent onGameCliented;
    public MakeLobby ml;
    public SteamP2PRelayTransport p2p;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(gameObject);
        SetupCallbacks();
    }

    public void SetupCallbacks()
    {
        SteamFriends.OnGameLobbyJoinRequested += OnGameInviteAccepted;
        SteamFriends.OnGameRichPresenceJoinRequested += OnGameRichPresenceJoinRequested;
    }

    public async void OnGameInviteAccepted(Lobby lobby, SteamId steamId)
    {
        Debug.Log("OnGameInivteAccepted called, trying to join lobby");
        UI_GameLog.gamelog("Trying To Join Lobby");
        await lobby.Join();
        UI_GameLog.gamelog("Lobby should be joined");
        onGameCliented.Invoke();
        ml.ClientJoinsLobby(lobby);
        NetworkManager.Singleton.StartClient();
    }
    public async void OnGameRichPresenceJoinRequested(Friend friend, string s)
    {
        Debug.Log("RichPresence Join Requested, trying to join lobby");
        UI_GameLog.gamelog("Trying To Join Lobby Via Richpresence");
        if (ulong.TryParse(s, out ulong seshID))
        {
            Lobby? lob = await SteamMatchmaking.JoinLobbyAsync(seshID);
            ml.ClientJoinsLobby(lob.Value);
        }
        UI_GameLog.gamelog("Lobby should be joined");


    }
}
