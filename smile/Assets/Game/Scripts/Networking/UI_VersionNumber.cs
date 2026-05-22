using TMPro;
using UnityEngine;

public class UI_VersionNumber : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = Application.version;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
