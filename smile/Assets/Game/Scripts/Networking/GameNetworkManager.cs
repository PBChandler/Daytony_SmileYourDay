using UnityEngine;
using Steamworks;
public class GameNetworkManager : MonoBehaviour
{
    public uint appID = 480;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        try
        {
            //SteamClient.Init(appID, true);
            Debug.Log("Steam is running");
        }catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    private void OnDisable()
    {
        try
        {
            //Steamworks.SteamClient.Shutdown();
        }catch(System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}
