using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class news_dialog : MonoBehaviour
{
    public TextMeshProUGUI textElement;
    int index = 0;
    public List<string> dialog = new List<string>();
    public void ADVANCE()
    {
        try
        {
             textElement.text = ">>"+dialog[index++];
        }catch{}
        
       
    }
    public void SetText(string whatever)
    {
        textElement.text = whatever;
    }
}
