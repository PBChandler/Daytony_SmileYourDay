using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class NWK_LobbyTracker : MonoBehaviour
{
    public MakeLobby ml;
    public TextMeshProUGUI label;
    public void Start()
    {
        label = GetComponent<TextMeshProUGUI>();
    }

    public void Update()
    {
        if(ml.myLobby.Data != null)
            setup();
    }

    public void setup()
    {
        string builder = "PLAYERS CONNECTED\n";

        foreach(var p in ml.myLobby.Members)
        {
            builder += p.Name + " | " + p.Nickname + "\n";
        }
        label.text = builder;
    }
}
