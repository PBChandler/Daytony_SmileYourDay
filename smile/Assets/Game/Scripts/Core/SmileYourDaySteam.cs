
using Steamworks;
using UnityEngine;

public class SmileYourDaySteam : MonoBehaviour
{
    public delegate void SYD_Missive(string missiveContents);
    public static SYD_Missive PostToEveryone_dg;
    public Callback<Steamworks.LobbyChatUpdate_t> OnLobbyEntered;
    public Callback<Steamworks.GameOverlayActivated_t> chat;
    
    void Start()
    {
        PostToEveryone_dg += SYD_Missive_Dummy;
        Invoke("Setup", 0.1f); //give it time to load.
    }

    public void Setup()
    {
        if(!SteamManager.Initialized) {Debug.LogError("STEAMMANAGER NOT INITLALIZED, MAKE SURE ENTRYNUMBER17 IS OPEN AND YOU HAVE STEAM OPEN ON YOUR PC."); return; }
        Debug.Log("KENDRICK");
        OnLobbyEntered = Callback<LobbyChatUpdate_t>.Create(OnLobbyMemberJoined);
        chat = Callback<Steamworks.GameOverlayActivated_t>.Create(Krist);
     }

     public void Krist(Steamworks.GameOverlayActivated_t bergentruck)
    {
        Debug.Log(bergentruck.m_bActive + "KENDRICK");
    }

     public void OTHER_OnLobbyEnteredSender(LobbyEnter_t chud)
    {
        
        
    }

    public void Update()
    {
        SteamAPI.RunCallbacks();
    }

    public void OnLobbyMemberJoined(LobbyChatUpdate_t pCallback)
    {
        Debug.Log("WE ARE KENDRICK LAMARRRRRRR");
        //if a FRIEND joins a LOBBY.
        if ((EChatMemberStateChange)pCallback.m_rgfChatMemberStateChange == EChatMemberStateChange.k_EChatMemberStateChangeEntered) {
            CSteamID memberId = (CSteamID)pCallback.m_ulSteamIDUserChanged;
            Debug.Log($"Player {SteamFriends.GetFriendPersonaName(memberId)} joined the lobby.");
            PostToEveryone_dg("OnLobbyEntered");
        }
    }

    public void ME_OnLobbyEnteredSender(LobbyEnter_t chud)
    {
        PostToEveryone_dg("me_OnLobbyEntered");
    }

    public void SYD_Missive_Dummy(string lol) { Debug.Log("lol" + " MISSIVE FIRED");}
  
}
