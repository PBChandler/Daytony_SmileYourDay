using System.Collections.Generic;
using JetBrains.Annotations;
using Steamworks;
using TMPro;
using UnityEngine;

public class NWK_LobbyTracker : MonoBehaviour
{
    public List<SteamworksLobbyButton> garfield = new List<SteamworksLobbyButton>();

    public void FixedUpdate()
    {
        //SteamFriends.GetFriendByIndex(0, EFriendFlags.k_EFriendFlagAll);
        for(int i = 0; i < garfield.Count; i++)
        {
            
        }
    }
}
