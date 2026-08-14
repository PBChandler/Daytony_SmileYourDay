using Steamworks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public bool lol;
    public void OnTriggerEnter(Collider other)
    {
        if (lol) return;
        SteamManager.Instance.currentLobby.Leave();
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Credits_NoNWK");
    }

    public void ApplIcationqu()
    {
        SteamClient.Shutdown();
        Application.Quit();
       
    }
}
