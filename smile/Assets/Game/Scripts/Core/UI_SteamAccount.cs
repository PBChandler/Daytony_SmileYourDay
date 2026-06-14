using UnityEngine;
using Steamworks;
using TMPro;
using UnityEngine.UI;
using Unity.Netcode;

public class UI_SteamAccount : MonoBehaviour
{

    public TextMeshProUGUI ProfileName;
    public RawImage profilePicture;
    // public CSteamID meRightNow;
    // public static int indexer = 0;
    // public Steamworks.LobbyCreated_t lobby_dg;
    // public Callback<Steamworks.LobbyCreated_t> OnLobbyCreatede;
    // public Callback<Steamworks.GameLobbyJoinRequested_t> LetMeIn;
    // public Callback<Steamworks.LobbyMatchList_t>MatchListChanged;
    // public Callback<Steamworks.LobbyEnter_t>LobbyingLikeCongress;
    // public Callback<Steamworks.LobbyDataUpdate_t>DATAUPDATE;

    // public Callback<Steamworks.LobbyChatUpdate_t>CHAT;
    public ulong LobbyID = 404404404404404404;
    public bool permissionToInvite = false;
}
    // public void OnEnable()
    // {
    //     return;
    //     if(NetworkManager.Singleton.IsHost)
    //     {
    //         Debug.Log("wait fuck is everyone the host?");
    //     }
    //    //if (SteamManager.Initialized) {
    //     //  OnLobbyCreatede = Callback<Steamworks.LobbyCreated_t>.Create(OnLobbyCreated);
    //     //  LetMeIn = Callback<Steamworks.GameLobbyJoinRequested_t>.Create(LetMeInReceiver);
    //     //  MatchListChanged = Callback<Steamworks.LobbyMatchList_t>.Create(MatchListChangedReceiver);
    //     //  LobbyingLikeCongress = Callback<Steamworks.LobbyEnter_t>.Create(LobbyingLikeCongressReceiver);
    //     //  DATAUPDATE = Callback<Steamworks.LobbyDataUpdate_t>.Create(DATAUPDATEReceiver);
    //     //  CHAT = Callback<Steamworks.LobbyChatUpdate_t>.Create(CHATReciever);
    //     //}
    // }
    

    // public void DATAUPDATEReceiver(Steamworks.LobbyDataUpdate_t kerk)
    // {
    //     Debug.Log("PLEASE GOD WILL SOMEONE WORK WILL ONE OF THESE WORK!!!!");
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
    // public void Populate(CSteamID ID_FRIEND)
    // {
    //     meRightNow = ID_FRIEND;
    //     profilePicture.texture = GetSmallAvatar(ID_FRIEND);
    //     ProfileName.text = SteamFriends.GetFriendPersonaName(ID_FRIEND)+"";
    // }

    // public void OnLobbyCreated(Steamworks.LobbyCreated_t dougdoug)
    // {
    //     if(!permissionToInvite) return;
    //     LobbyID = dougdoug.m_ulSteamIDLobby;
    //     Debug.Log("INVITE FAKE SENT TO " + SteamFriends.GetFriendPersonaName(meRightNow));
    //     SteamMatchmaking.InviteUserToLobby((CSteamID)LobbyID, meRightNow);
    //     permissionToInvite = false;
    // }

    // public void JOINFRIEND()
    // {
    
    //     SteamMatchmaking.JoinLobby(meRightNow);       
    // }
    // public async void INVITE_FRIEND()
    // {
    //     permissionToInvite = true;
    //     SteamMatchmaking.CreateLobby(ELobbyType.k_ELobbyTypePublic, 2);
    //     if(LobbyID != 404404404404404404)
    //     {
    //         SteamMatchmaking.InviteUserToLobby((CSteamID)LobbyID, meRightNow); //yes, you can spam your friends.
    //     }
    // }

/// <summary>
/// THANK YOU ZITZ ON REDDIT FROM GENUINELY 10 YEARS AGO
/// </summary>
/// <param name="user"></param>
/// <returns></returns>
    // public Texture2D GetSmallAvatar(CSteamID user)
    // {
    //     int FriendAvatar = SteamFriends.GetSmallFriendAvatar(user);
    //     uint ImageWidth;
    //     uint ImageHeight;
    //     bool success = SteamUtils.GetImageSize(FriendAvatar, out ImageWidth, out ImageHeight);

    //     if (success && ImageWidth > 0 && ImageHeight > 0)
    //     {
    //         byte[] Image = new byte[ImageWidth * ImageHeight * 4];
    //         Texture2D returnTexture = new Texture2D((int)ImageWidth, (int)ImageHeight, TextureFormat.RGBA32, false, true);
    //         success = SteamUtils.GetImageRGBA(FriendAvatar, Image, (int)(ImageWidth * ImageHeight * 4));
    //         if (success)
    //         {
    //             returnTexture.LoadRawTextureData(Image);
    //             returnTexture.Apply();
    //         }
    //         return returnTexture;
    //     }
    //     else
    //     {
    //         Debug.LogError("Couldn't get avatar.");
    //         return new Texture2D(0, 0);
    //     }
    // }   

