using UnityEngine.UI;
using Mirror;
using UnityEngine;

public class NetworkButtonPress : NetworkBehaviour
{
    public Image be;
    [ClientRpc]
    public void ClickButton()
    {
        UpdateButton();
    }

    [TargetRpc]
    public void UpdateButton()
    {
        if(be.color == Color.green)
        {
            be.color = Color.red;
        }
        else
        {
            be.color = Color.green;
        }
    }
}
