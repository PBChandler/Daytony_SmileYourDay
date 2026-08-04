using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StupidNetworkSceneLoader : MonoBehaviour
{
    public float timeTillThanging;
    public string sceneName;
    public bool reuse;
    void Start()
    {
        if(!reuse)
         Invoke("doit", timeTillThanging);
    }

    public void CALLSCENELOAD()
    {
        doit();
    }
    public void doit()
    {
        try
        {
            NetworkManager.Singleton.SceneManager.LoadScene(sceneName, UnityEngine.SceneManagement.LoadSceneMode.Single);
        }
        catch
        {
            SceneManager.LoadScene(sceneName);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
