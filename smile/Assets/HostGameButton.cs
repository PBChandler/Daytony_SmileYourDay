using UnityEngine;
using Steamworks;
using Unity.Netcode;
using System.Threading.Tasks;
using Steamworks.Data;
public class HostGameButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        superOnClick();
        
    }

    public async void superOnClick()
    {
        await startLobby();
    
    }


    public void killLobby()
    {
        SteamManager.Instance.currentLobby.Leave();
    }
    public async Task startLobby()
    {
        await SteamManager.Instance.CreateLobby(0);
        SteamFriends.OpenGameInviteOverlay(SteamManager.Instance.currentLobby.Id);
    }
}
