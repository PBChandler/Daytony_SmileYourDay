using Microsoft.Unity.VisualStudio.Editor;
using Unity.Netcode;
using UnityEngine;

public class NetworkedLobbyUIManager : NetworkBehaviour
{
    public talkToTaskList hostList, clientList;

    public void Start()
    {
        
    }
    public void SetHostButtonClicked()
    {
        hostList.CommunicateToServer();
    }

    public void SetClientButtonClicked()
    {
        clientList.CommunicateToServer();
    }

    public void washi(int washiwashi)
    {
        washiRpc(washiwashi);
    }
    [Rpc(SendTo.Everyone, InvokePermission = RpcInvokePermission.Everyone)]
    public void washiRpc(int washi)
    {
        if(washi == 0)
            SetHostButtonClicked();
        else
            SetClientButtonClicked();
    }
}
