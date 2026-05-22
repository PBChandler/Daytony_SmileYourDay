using Steamworks;
using Steamworks.Data;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
public class MakeLobby : MonoBehaviour
{
    public Lobby myLobby;
    public string friendToAnnoy = "Shwingle";
    public bool annoyBen;
    public NetworkManager networkManager;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(gameObject);
        SetupCallbacks();
    }

    public UnityEvent onGameHosted;


    public void SetupCallbacks()
    {
        SteamMatchmaking.OnLobbyCreated += OnLobbyCreate;
        SteamMatchmaking.OnLobbyMemberJoined += OnLobbyMemberJoined;
    }

    public void ClientJoinsLobby(Lobby l)
    {
        Debug.Log("I have joined a server!" + l.Owner + " is the owner!");
        myLobby = l;
        NetworkManager.Singleton.StartClient();
        if(NetworkManager.Singleton.SceneManager == null)
        {
            Debug.Log("It's gonna fucking fail dude fuck you fuck off die");
        }

    
        SteamFriends.SetRichPresence("steam_display", "#Status_InGame");
        SteamFriends.SetRichPresence("location", "Tom Cruise's House");
    }

    [ServerRpc]
    public void LoadMouseRpc()
    {
        GetMouseRpc();
    }
    [Rpc(SendTo.Everyone)]
    public void GetMouseRpc()
    {
        NetworkManager.Singleton.SceneManager.LoadScene("EntryNumber17", UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
    public void OnLobbyCreate(Result res, Lobby lobby)
    {
        try
        {
            if(!myLobby.Id.IsValid)
            {
                myLobby = lobby;
                Debug.Log("Created Lobby");
                myLobby.SetJoinable(true);
                myLobby.SetPublic();
                
                onGameHosted.Invoke();
               
                NetworkManager.Singleton.StartServer();
                 NetworkManager.Singleton.StartClient();
                  LoadMouseRpc();
                //do anything I need to do Lobby stuff with here smile
                if(annoyBen)
                    Invoke("testInviteFriend", 1f);
            }
        }
        catch
        {
            Debug.Log("CRY");
        }
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            LoadMouseRpc();
        }
        
    }
    public void OnLobbyMemberJoined(Lobby lobby, Friend friend)
    {
        if(NetworkManager.Singleton.IsServer)
        {
           
        }

        Debug.Log(friend.Name + "is joining lobby");
    }

    public void buttonAccessSetup()
    {
        setupLobby();
    }
    public async void setupLobby()
    {
        await SteamMatchmaking.CreateLobbyAsync(2);

    }


    void testInviteFriend()
    {
        foreach(var player in SteamFriends.GetFriends())
        {
            if(player.Name == friendToAnnoy)
            {
                myLobby.SetJoinable(true);
                myLobby.SetPublic();
                Debug.Log("smiting ben");
                Debug.Log(myLobby.Id.ToString());
                player.InviteToGame(myLobby.Id.ToString());
            }
            else
            {
                Debug.Log(player.Name);
            }
        }
    }
}
