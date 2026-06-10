using UnityEngine.UI;
using Mirror;
using UnityEngine;

public class NetworkButtonPress : NetworkBehaviour
{
    public Image be;
    [Command(requiresAuthority = false)]
    public void ClickButton()
    {
        allowbuttonpress();
    }

    [Server]
    public void allowbuttonpress()
    {
        UpdateButton();
    }

    [ClientRpc]
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
