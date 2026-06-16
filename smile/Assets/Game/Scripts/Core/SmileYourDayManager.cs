using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class SmileYourDayManager : NetworkBehaviour
{
    public static SmileYourDayManager instance;

    public static NetworkVariable<PlayerHeaven> Runner, Hacker;

    public Camera rendertextureCamera;
    public void Start()
    {
        if(SmileYourDayManager.instance != null && SmileYourDayManager.instance != this)
        Destroy(this);
        
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            InitilaizeGame();
        }
    }
    public void InitilaizeGame()
    {
        rendertextureCamera.transform.parent = Runner.Value.gameObject.transform.Find("EYES");
    }
}
