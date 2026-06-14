
using Steamworks;
using UnityEngine;
public class SmileYourDaySteam : MonoBehaviour
{
    public delegate void SYD_Missive(string missiveContents);
    public static SYD_Missive PostToEveryone_dg;
    // public Callback<Steamworks.LobbyChatUpdate_t> OnLobbyEntered;
    // public Callback<Steamworks.GameOverlayActivated_t> chat;

    // public Callback<Steamworks.GameLobbyJoinRequested_t> LetMeIn;
    // public Callback<Steamworks.LobbyMatchList_t>MatchListChanged;
    // public Callback<Steamworks.LobbyEnter_t>LobbyingLikeCongress;
    // public Callback<Steamworks.LobbyDataUpdate_t>DATAUPDATE;

    // public Callback<Steamworks.LobbyChatUpdate_t>CHAT;
    public void Awake()
    {
        // if (Instance == null)
        // {
        //     daRealOne = true;
        //     DontDestroyOnLoad(gameObject);
        //     Instance = this;
        //     PlayerName = "";
        //     try
        //     {
        //         // Create client
        //         SteamClient.Init(gameAppId, true);
        //         if (!SteamClient.IsValid)
        //         {
        //             Debug.Log("Steam client not valid");
        //             throw new Exception();
        //         }
        //         PlayerName = SteamClient.Name;
        //         PlayerSteamId = SteamClient.SteamId;
        //         playerSteamIdString = PlayerSteamId.ToString();
        //         activeUnrankedLobbies = new List<Lobby>();
        //         activeRankedLobbies = new List<Lobby>();
        //         connectedToSteam = true;
        //         Debug.Log("Steam initialized: " + PlayerName);
        //     }
        //     catch (Exception e)
        //     {
        //         connectedToSteam = false;
        //         playerSteamIdString = "NoSteamId";
        //         Debug.Log("Error connecting to Steam");
        //         Debug.Log(e);
        //     }
        // }
        // else if (Instance != this)
        // {
        //     Destroy(gameObject);
        // }
    }
    void Start()
    {
        PostToEveryone_dg += SYD_Missive_Dummy;
        Invoke("Setup", 0.1f); //give it time to load.
    }

    public void Setup()
    {
        // if(!SteamManager.Initialized) {Debug.LogError("STEAMMANAGER NOT INITLALIZED, MAKE SURE ENTRYNUMBER17 IS OPEN AND YOU HAVE STEAM OPEN ON YOUR PC."); return; }
        // Debug.Log("KENDRICK");
        // OnLobbyEntered = Callback<LobbyChatUpdate_t>.Create(OnLobbyMemberJoined);
        // chat = Callback<Steamworks.GameOverlayActivated_t>.Create(Krist);
        // //OnLobbyCreatede = Callback<Steamworks.LobbyCreated_t>.Create(OnLobbyCreated);
        //  LetMeIn = Callback<Steamworks.GameLobbyJoinRequested_t>.Create(LetMeInReceiver);
        //  MatchListChanged = Callback<Steamworks.LobbyMatchList_t>.Create(MatchListChangedReceiver);
        //  LobbyingLikeCongress = Callback<Steamworks.LobbyEnter_t>.Create(LobbyingLikeCongressReceiver);
        //  DATAUPDATE = Callback<Steamworks.LobbyDataUpdate_t>.Create(DATAUPDATEReceiver);
        //  CHAT = Callback<Steamworks.LobbyChatUpdate_t>.Create(CHATReciever);
    }

    //  public void Krist(Steamworks.GameOverlayActivated_t bergentruck)
    // {
    //     Debug.Log(bergentruck.m_bActive + "KENDRICK");
    // }

    //  public void OTHER_OnLobbyEnteredSender(LobbyEnter_t chud)
    // {


    // }

    public void Update()
    {
        // SteamAPI.RunCallbacks();
        // if(!SteamAPI.Init())
        // {
        //     Debug.Log("STEAM API IS NOT ACTIVE, STOP EVERYTHINGG!!!!!");
        // }
    }

    // public void DATAUPDATEReceiver(Steamworks.LobbyDataUpdate_t kerk)
    // {
    //     Debug.Log("PLEASE GOD WILL SOMEONE WORK WILL ONE OF THESE WORK!!!!");
    //     //  if ((EChatMemberStateChange)pCallback.m_rgfChatMemberStateChange == EChatMemberStateChange.k_EChatMemberStateChangeEntered) {
    //     //     CSteamID memberId = (CSteamID)pCallback.m_ulSteamIDUserChanged;
    //     //     Debug.Log($"Player {SteamFriends.GetFriendPersonaName(memberId)} joined the lobby.");
    //     //     PostToEveryone_dg("OnLobbyEntered");
    //     // }
    //     Debug.Log(kerk.m_ulSteamIDMember);
    // }

    // public void CHATReciever(Steamworks.LobbyChatUpdate_t carolknight)
    // {
    //     Debug.Log("Carol"+carolknight.m_ulSteamIDLobby);
    // }
    /// <summary>
    /// understanding
    /// </summary>
    /// <param name="burger"></param>
    // public void LetMeInReceiver(Steamworks.GameLobbyJoinRequested_t burger)
    // {
    //     Debug.Log("I'm trying to break into" + SteamFriends.GetFriendPersonaName(burger.m_steamIDFriend) + "'s lobby");
    // }

    // public void LobbyingLikeCongressReceiver(Steamworks.LobbyEnter_t benisherenow)
    // {
    //     Debug.Log("HELLO? HIIII??? HELLO??? IS SOMEONE JOINING THE FUCKING LOBBY???" + benisherenow.m_EChatRoomEnterResponse);
    // }
    // public void MatchListChangedReceiver(Steamworks.LobbyMatchList_t benisherenow)
    // {
    //     Debug.Log("matchlist updated smile" + benisherenow.m_nLobbiesMatching);
    // }
    // public void OnLobbyMemberJoined(LobbyChatUpdate_t pCallback)
    // {
    //     Debug.Log("WE ARE KENDRICK LAMARRRRRRR");
    //     //if a FRIEND joins a LOBBY.
    //     if ((EChatMemberStateChange)pCallback.m_rgfChatMemberStateChange == EChatMemberStateChange.k_EChatMemberStateChangeEntered) {
    //         CSteamID memberId = (CSteamID)pCallback.m_ulSteamIDUserChanged;
    //         Debug.Log($"Player {SteamFriends.GetFriendPersonaName(memberId)} joined the lobby.");
    //         PostToEveryone_dg("OnLobbyEntered");
    //     }
    // }

    // public void ME_OnLobbyEnteredSender(LobbyEnter_t chud)
    // {
    //     PostToEveryone_dg("me_OnLobbyEntered");
    // }

    public void SYD_Missive_Dummy(string lol) { Debug.Log("lol" + " MISSIVE FIRED"); }

}
