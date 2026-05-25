using UnityEngine;
using UnityEngine.SceneManagement;

public class Gaster
{
    //freedom motif
    //if you're datamining this game and finding our bullshit deltarune references instead of lore, I apologize
    //I promise you we aint toby fox there is no lore in the code bro

    public static string DEVICE_SCENE;
    [RuntimeInitializeOnLoadMethod]
    public static void OnPlayModeEntered()
    {
        DEVICE_SCENE = SceneManager.GetActiveScene().name;
        #if UNITY_EDITOR
        SceneManager.LoadScene("EntryNumber17");
        #endif
    }

}
