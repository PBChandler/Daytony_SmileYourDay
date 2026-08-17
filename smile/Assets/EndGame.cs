using Steamworks;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public bool lol;
    public void OnTriggerEnter(Collider other)
    {
        if (lol) return;
        if(other.tag == "Player")
        SmileYourDayTaskList.instance.endthevideogameRPC();
    }

    public void ApplIcationqu()
    {
        SteamClient.Shutdown();
        Application.Quit();
       
    }
}
