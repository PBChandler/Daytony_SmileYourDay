using UnityEngine;

public class SmileGameManager : MonoBehaviour
{
    public static SmileGameManager instance;
    public bool Testing = false; //enable for suite of testing features, mainly not being in steam.
    public void Start()
    {
        if(SmileGameManager.instance != this && SmileGameManager.instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }
}
