using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    void OnEnable()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("TitleScreen", UnityEngine.SceneManagement.LoadSceneMode.Additive);
        }
    }
}
