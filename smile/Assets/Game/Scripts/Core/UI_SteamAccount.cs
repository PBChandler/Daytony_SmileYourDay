using UnityEngine;
using Steamworks;
using TMPro;
using UnityEngine.UI;
using Unity.Netcode;
using Steamworks.Data;
using System.Threading.Tasks;
using System;
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
    public Steamworks.Friend meRightNow;

    public void OnEnable()
    {
        Steamworks.SteamFriends.GetFriends();
    
        }

    public void Carbomb()
    {
        explode();
    }
    public async void explode()
    {Debug.Log("Population Started");
        await Populate(meRightNow);
    }
    public async Task Populate(Steamworks.Friend ID_FRIEND)
    {
        meRightNow = ID_FRIEND;
        Steamworks.Data.Image? im = await SteamFriends.GetSmallAvatarAsync(ID_FRIEND.Id);
         profilePicture.texture = Convert(im.Value);
         
       ProfileName.text = meRightNow.Name;
    }

    public async Task Populate(Steamworks.SteamId ID)
    {
         Steamworks.Friend friend = new Friend(ID);
         meRightNow = friend;
        Steamworks.Data.Image? im = await SteamFriends.GetSmallAvatarAsync(ID);
         profilePicture.texture = Convert(im.Value);
        
       ProfileName.text = friend.Name;
    }
    public Texture2D Convert(Steamworks.Data.Image image )
    {
        // Create a new Texture2D
        var avatar = new Texture2D( (int)image.Width, (int)image.Height, TextureFormat.ARGB32, false );
        
        // Set filter type, or else its really blury
        avatar.filterMode = FilterMode.Trilinear;

        // Flip image
        for ( int x = 0; x < image.Width; x++ )
        {
            for ( int y = 0; y < image.Height; y++ )
            {
                var p = image.GetPixel( x, y );
                avatar.SetPixel( x, (int)image.Height - y, new UnityEngine.Color( p.r / 255.0f, p.g / 255.0f, p.b / 255.0f, p.a / 255.0f ) );
            }
        }
        
        avatar.Apply();
        return avatar;
    }
}