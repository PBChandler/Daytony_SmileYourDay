using Unity.Netcode;
using UnityEngine;

public class NetworkSceneLoader : MonoBehaviour
{
    public float timeTillThanging = 1.67f;
    public string sceneName;
    public bool isGaster;

    public void OnEnable()
    {
        if(isGaster && !Gaster.DEVICE_SCENE.Contains("_NoNWK"))
        {
            sceneName = Gaster.DEVICE_SCENE;
            timeTillThanging = 0.67f; //SIX SEVEN
        }
        Invoke("DoYaThang", timeTillThanging);
    }
    public void DoYaThang()
    {
        NetworkManager.Singleton.StartHost();
        NetworkManager.Singleton.SceneManager.LoadScene(sceneName, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
}
