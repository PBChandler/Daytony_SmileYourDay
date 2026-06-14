using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkSceneLoader : MonoBehaviour
{
    public float timeTillThanging = 1.67f;
    public string sceneName;
    public bool isGaster;

    public bool forceClient = false;
    public void OnEnable()
    {

        Gaster aGaster = Gaster.instance;
        try
        {
            if (isGaster && !Gaster.DEVICE_SCENE.Contains("_NoNWK") && Gaster.DEVICE_SCENE != "EntryNumber17") //can't have the funny infinite loop cos it breaks the multiplayer hting
            {
                sceneName = Gaster.DEVICE_SCENE;
                timeTillThanging = 0.67f; //SIX SEVEN
            }
            Invoke("DoYaThang", timeTillThanging);
        }
        catch
        {
Invoke("DoYaThang", timeTillThanging);
        }

    }

    public void Update()
    {
        if(Input.GetKey(KeyCode.C))
        {
            forceClient = true;
            try
            {
                 NetworkManager.Singleton.StartClient();
            }
            catch
            {
                
            }
        }
    }
    public void DoYaThang()
    {
        if(NetworkManager.Singleton == null)
        {
            SceneManager.LoadScene(sceneName, UnityEngine.SceneManagement.LoadSceneMode.Single);
            return; //if playing in "DEFAULT"
        }
        // if(forceClient)
        //     NetworkManager.Singleton.StartClient();
        // else
        //     NetworkManager.Singleton.StartHost();
        try
        {
            NetworkManager.Singleton.SceneManager.LoadScene(sceneName, UnityEngine.SceneManagement.LoadSceneMode.Single);
        }
        catch
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
        
    }
}
