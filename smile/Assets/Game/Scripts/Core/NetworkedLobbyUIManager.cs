using Microsoft.Unity.VisualStudio.Editor;
using Unity.Netcode;
using UnityEngine;

public class NetworkedLobbyUIManager : MonoBehaviour
{
    public talkToTaskList hostList, clientList;

    public void Start()
    {
        Invoke("explosion", 0.1f);
    }

    public void explosion()
    {
        SmileYourDayTaskList.instance.dg_Heaven += hostClicked;
        SmileYourDayTaskList.instance.dg_Heaven += clientClicked;
    }
    
    public void SetHostButtonClicked()
    {
        hostList.CommunicateToServer();
    }

    public void hostClicked(string burger)
    {
        SetHostButtonClicked();
    }

    public void clientClicked(string burger)
    {
        SetClientButtonClicked();
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
