using UnityEngine;
using Steamworks;
using TMPro;
using UnityEngine.UI;

public class UI_SteamAccount : MonoBehaviour
{

    public TextMeshProUGUI ProfileName;
    public RawImage profilePicture;
    public CSteamID meRightNow;
    public static int indexer = 0;
    public Steamworks.LobbyCreated_t lobby_dg;
    public Callback<Steamworks.LobbyCreated_t> OnLobbyCreatede;
    public ulong LobbyID = 404404404404404404;
    public bool permissionToInvite = false;
    public void OnEnable()
    {
       if (SteamManager.Initialized) {
         OnLobbyCreatede = Callback<Steamworks.LobbyCreated_t>.Create(OnLobbyCreated);
        }
    }

    public void Populate(CSteamID ID_FRIEND)
    {
        meRightNow = ID_FRIEND;
        profilePicture.texture = GetSmallAvatar(ID_FRIEND);
        ProfileName.text = SteamFriends.GetFriendPersonaName(ID_FRIEND)+"";
    }

    public void OnLobbyCreated(Steamworks.LobbyCreated_t dougdoug)
    {
        if(!permissionToInvite) return;
        LobbyID = dougdoug.m_ulSteamIDLobby;
        Debug.Log("INVITE FAKE SENT TO " + SteamFriends.GetFriendPersonaName(meRightNow));
        SteamMatchmaking.InviteUserToLobby((CSteamID)LobbyID, meRightNow);
        permissionToInvite = false;
    }
    public async void INVITE_FRIEND()
    {
        permissionToInvite = true;
        SteamMatchmaking.CreateLobby(ELobbyType.k_ELobbyTypePublic, 2);
        if(LobbyID != 404404404404404404)
        {
            SteamMatchmaking.InviteUserToLobby((CSteamID)LobbyID, meRightNow); //yes, you can spam your friends.
        }
    }

/// <summary>
/// THANK YOU ZITZ ON REDDIT FROM GENUINELY 10 YEARS AGO
/// </summary>
/// <param name="user"></param>
/// <returns></returns>
    public Texture2D GetSmallAvatar(CSteamID user)
    {
        int FriendAvatar = SteamFriends.GetSmallFriendAvatar(user);
        uint ImageWidth;
        uint ImageHeight;
        bool success = SteamUtils.GetImageSize(FriendAvatar, out ImageWidth, out ImageHeight);

        if (success && ImageWidth > 0 && ImageHeight > 0)
        {
            byte[] Image = new byte[ImageWidth * ImageHeight * 4];
            Texture2D returnTexture = new Texture2D((int)ImageWidth, (int)ImageHeight, TextureFormat.RGBA32, false, true);
            success = SteamUtils.GetImageRGBA(FriendAvatar, Image, (int)(ImageWidth * ImageHeight * 4));
            if (success)
            {
                returnTexture.LoadRawTextureData(Image);
                returnTexture.Apply();
            }
            return returnTexture;
        }
        else
        {
            Debug.LogError("Couldn't get avatar.");
            return new Texture2D(0, 0);
        }
    }   
}
