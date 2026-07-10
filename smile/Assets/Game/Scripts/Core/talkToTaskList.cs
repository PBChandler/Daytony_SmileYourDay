using System.Threading.Tasks;
using Steamworks;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class talkToTaskList : MonoBehaviour
{
    public UI_SteamAccount possiblyMe;
    public int type = 0; //0 = runner 1 = hacker

    public bool lockedIn = false;
    void Start()
    {
        if (possiblyMe != null)
        {
            Invoke("burgerSummoner", 0.5f);
        }
    }

    public void burgerSummoner()
    {
        burger(type);
    }
    public async void burger(int a)
    {
        a = type;
        await setPortrait(a);
    }
    public async Task setPortrait(int mode)
    {
        switch (mode)
        {
            case 0:
                await possiblyMe.Populate(SmileYourDayTaskList.instance.client);
                break;
            case 1:
                await possiblyMe.Populate(SmileYourDayTaskList.instance.host);
                break;
            case 2:
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateTaskList(string message)
    {
        if(lockedIn) return;
        CommunicateToServerRpc();
        SmileYourDayTaskList.instance.UpdateGameTask(message, 1);
    }
    [Rpc(SendTo.Everyone, InvokePermission = RpcInvokePermission.Everyone)]
    public void CommunicateToServerRpc()
    {
        lockedIn = true;
        GetComponent<Image>().color = Color.black;
    }
    
}
