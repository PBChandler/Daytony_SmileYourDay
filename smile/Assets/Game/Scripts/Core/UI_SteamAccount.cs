using UnityEngine;
using Steamworks;
using TMPro;
using UnityEngine.UI;

public class UI_SteamAccount : MonoBehaviour
{

    public TextMeshProUGUI ProfileName;
    public RawImage profilePicture;

    public static int indexer = 0;

    public void Start()
    {
        Invoke("Populate", 1f);
    }

    public void Populate()
    {
        CSteamID ID_FRIEND = SteamFriends.GetFriendByIndex(indexer++, EFriendFlags.k_EFriendFlagAll); //always at your humble service
        
        profilePicture.texture = GetSmallAvatar(ID_FRIEND);
        ProfileName.text = SteamFriends.GetFriendPersonaName(ID_FRIEND)+"";
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
