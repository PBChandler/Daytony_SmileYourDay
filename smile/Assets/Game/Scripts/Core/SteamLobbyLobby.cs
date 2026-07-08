using UnityEngine;
using Steamworks;
using System.Collections.Generic;
public class SteamLobbyLobby : MonoBehaviour
{
    public List<SteamProfile> FRIEND_Friend;
    public List<UI_SteamAccount> bubblesOfFriends;
    
    public Texture2D lastPFP;
    public void Start()
    {
        //FIND MY FRIENDS
        // /int FriendCount = SteamFriends.GetFriendCount(EFriendFlags.k_EFriendFlagImmediate);
        // for(int i = 0; i < FriendCount; i++)
        // {
        //     SteamProfile friend = new SteamProfile();
        //    // CSteamID ID_FRIEND = SteamFriends.GetFriendByIndex(i, EFriendFlags.k_EFriendFlagAll); //always at your humble service
        
        //    // friend.CFRIENDID = ID_FRIEND; 
        //    // friend.ICON = GetSmallAvatar(ID_FRIEND);
        //    // friend.DISPLAYNAME = SteamFriends.GetFriendPersonaName(ID_FRIEND)+"";
        //     if(friend.DISPLAYNAME == "[unknown]") continue; //remove hidden friends?
        //     FRIEND_Friend.Add(friend);
        //     lastPFP = friend.ICON;
        // }
        // // for(int i = 0; i < 5; i++)
        // // {
        // //     dissapointment();
        // // }
        // LoadPage(0);
    }

    public void dissapointment() //I did NOT feel like coding this properly
    {
        if(FRIEND_Friend.Count % 5 != 0) 
        {
            SteamProfile friend = new SteamProfile();
            //friend.CFRIENDID = FRIEND_Friend[0].CFRIENDID;
            friend.ICON = lastPFP;
            friend.DISPLAYNAME = "IMAGE_FRIEND";
        }
    }


    public int pageNumber;
    public void LoadNextPage()
    {
        if(pageNumber + 5 > FRIEND_Friend.Count)
        {
            
            pageNumber = FRIEND_Friend.Count-5;
            if(pageNumber < 0) //bro only has five friends sadge
            {
                pageNumber = 0;
            }
        }
        else
        {
            pageNumber += 5;
        }
        
        LoadPage(pageNumber);
    }

    public void LoadLastPage()
    {
        if(pageNumber - 5 < 0)
        {
            pageNumber = 0;
        }
        else
        {
            pageNumber -= 5;
        }

        LoadPage(pageNumber);
    }
    public void LoadPage(int pageIndex)
    {
        for(int i = 0; i < bubblesOfFriends.Count; i++)
        {
            try
            {
                //bubblesOfFriends[i].Populate(FRIEND_Friend[i+pageIndex].CFRIENDID);
            }
            catch
            {
                // bubblesOfFriends[i].ProfileName.text = "NO_FRIEND";
                // bubblesOfFriends[i].profilePicture.texture = null;
            }
            
        }
    }

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
}
[System.Serializable]
public struct SteamProfile
{
    public Texture2D ICON;
    public string DISPLAYNAME;
}
