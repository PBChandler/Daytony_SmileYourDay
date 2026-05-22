using Unity.Netcode;
using UnityEngine;

public class NWK_SimpleButton : NetworkBehaviour
{
    public UnityEngine.UI.Image image;
    [Rpc(SendTo.ClientsAndHost)]
    public void pressButtonRpc()
    {
        
    }
}
