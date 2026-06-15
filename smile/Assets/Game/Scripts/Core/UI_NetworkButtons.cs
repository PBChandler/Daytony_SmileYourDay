using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
using Steamworks;
/// <summary>
/// This script is specifically to connect the "On Host" and "On Client" buttons to our game, not anything else. might go unused in final.
/// </summary>
public class UI_NetworkButtons : MonoBehaviour
{
    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;
    //public MakeLobby lobby;

    private void Start()
    {
        hostButton.onClick.AddListener(HostButtonOnClick);
        //sclientButton.onClick.AddListener(ClientButtonOnClick);

    }

    public void HostButtonOnClick()
    {
        //
        //NetworkManager.Singleton.StartHost();

       // SteamMatchmaking.CreateLobby(ELobbyType.k_ELobbyTypePublic, 2);
        SteamFriends.SetRichPresence("steam_display", "#Status_AtMainMenu");
        // lobby.buttonAccessSetup();
    }
    // protected Callback<LobbyEnter_t> m_LobbyEntered;
    // public void ClientButtonOnClick()
    // {
    //    m_LobbyEntered = Callback<LobbyEnter_t>.Create(OnLobbyEntered);
    //     NetworkManager.Singleton.StartClient();
    // }

    // void OnLobbyEntered(LobbyEnter_t pCallback) {
    //     CSteamID lobbyID = new CSteamID(pCallback.m_ulSteamIDLobby);
    //     Debug.Log("Entered Lobby ID: " + lobbyID.ToString());
    //     NetworkManager.Singleton.StartClient();
    //     SteamMatchmaking.JoinLobby(lobbyID);
    // }
    public void InviteFriends()
    {

    }
}
