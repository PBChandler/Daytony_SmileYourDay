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
        SteamFriends.OnGameLobbyJoinRequested += SteamFriends_OnGameLobbyJoinRequested;
    }

    private void SteamFriends_OnGameLobbyJoinRequested(Steamworks.Data.Lobby arg1, SteamId arg2)
    {
        tmpro.text = "JOIN " + new Friend(arg2).Name + "'s LOBBY"; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
