using Steamworks;
using UnityEngine;

public class SmileYourDaySteam : MonoBehaviour
{
    public delegate void SYD_Missive(string missiveContents);
    public static SYD_Missive PostToEveryone_dg;
    public Callback<Steamworks.LobbyEnter_t> OnLobbyEntered;
    void Start()
    {
        PostToEveryone_dg += SYD_Missive_Dummy;
        Invoke("Setup", 0.1f); //give it time to load.
    }

    public void Setup()
    {
        if(!SteamManager.Initialized) {Debug.LogError("STEAMMANAGER NOT INITLALIZED, MAKE SURE ENTRYNUMBER17 IS OPEN AND YOU HAVE STEAM OPEN ON YOUR PC."); return; }

        OnLobbyEntered = Callback<LobbyEnter_t>.Create(OnLobbyEnteredSender);
     }

     public void OnLobbyEnteredSender(LobbyEnter_t chud)
    {
        PostToEveryone_dg("OnLobbyEntered");
    }

    public void SYD_Missive_Dummy(string lol) { Debug.Log("lol" + " MISSIVE FIRED");}
    // Update is called once per frame
    void Update()
    {
        
    }
}
