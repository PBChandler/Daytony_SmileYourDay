using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAfterSeconds : MonoBehaviour
{
    public string sceneName;
    public float seconds;
    
    public void Start()
    {
        Invoke("loadscene", seconds);
    }

    public void loadscene()
    {
        sceneName = Gaster.DEVICE_SCENE;
        SceneManager.LoadScene(sceneName);
    }
}
