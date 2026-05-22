using TMPro;
using UnityEngine;

public class UI_GameLog : MonoBehaviour
{
    public TextMeshProUGUI me;
    public static UI_GameLog log;

    public void Start()
    {
        log = this;
    }
    public static void gamelog(string message)
    {
        log.me.text += "\n"+message;
    }
}
