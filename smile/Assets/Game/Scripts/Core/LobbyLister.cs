using UnityEngine;
using TMPro;
public class LobbyLister : MonoBehaviour
{
    public TextMeshProUGUI clark;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            clark.text = SteamManager.Instance.LobbyPartner + "";
        }
        catch
        {
            
        }
    }
}
