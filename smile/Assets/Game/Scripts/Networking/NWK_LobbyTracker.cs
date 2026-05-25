using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class NWK_LobbyTracker : MonoBehaviour
{
    //public MakeLobby ml;
    public TextMeshProUGUI label;
    public void Start()
    {
        label = GetComponent<TextMeshProUGUI>();
    }

    public void Update()
    {
        //don't run this code if smile your game manager is in "Testing" (I.E not STEAM) mode.
        //if(ml.myLobby.Data != null && !SmileGameManager.instance.Testing)
            setup();
    }

    public void setup()
    {
        string builder = "PLAYERS CONNECTED\n";

       
        label.text = builder;
    }
}
