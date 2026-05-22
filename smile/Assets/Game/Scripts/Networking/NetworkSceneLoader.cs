using Unity.Netcode;
using UnityEngine;

public class NetworkSceneLoader : MonoBehaviour
{
    public float timeTillThanging = 1.67f;
    public string sceneName;

    public void OnEnable()
    {
        Invoke("DoYaThang", timeTillThanging);
    }
    public void DoYaThang()
    {
        NetworkManager.Singleton.StartHost();
        NetworkManager.Singleton.SceneManager.LoadScene(sceneName, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
}
