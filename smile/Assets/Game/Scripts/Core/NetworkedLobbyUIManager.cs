using Microsoft.Unity.VisualStudio.Editor;
using Unity.Netcode;
using UnityEngine;

public class NetworkedLobbyUIManager : NetworkBehaviour
{
    public talkToTaskList hostList, clientList;

    public void SetHostButtonClicked()
    {
        hostList.CommunicateToServer();
    }

    public void SetClientButtonClicked()
    {
        clientList.CommunicateToServer();
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
