using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JoinAFriendButton : MonoBehaviour
{
    public TextMeshProUGUI tmpro;
    public Button m_button;
    void Start()
    {
        //SteamFriends.OnGameRichPresenceJoinRequested += SteamFriends_OnGameLobbyJoinRequested;
    }
    //there literally does not exist functionality for this in Facepunch it would seem.
    //private void SteamFriends_OnGameLobbyJoinRequested(Friend f, string fe)
    //{
    //    Debug.Log("Someone's trying to invite you to their lobby");
    //    tmpro.text = "JOIN " + f.Name + "'s LOBBY"; 
    //}

    //// Update is called once per frame
    //void FixedUpdate()
    //{
    //    foreach(Friend f in SteamFriends.GetFriends())
    //    {
    //        if(f.IsPlayingThisGame)
    //        {
    //            tmpro.text = "JOIN " + f.Name + "'s LOBBY";
    //        }
    //    }
    //}
}
