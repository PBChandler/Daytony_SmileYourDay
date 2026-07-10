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
    public string mess;
    public bool lockedIn = false;
    public delegate void cheater();
    public cheater dg_Cheater;
    void Start()
    {
        if (possiblyMe != null)
        {
            Invoke("burgerSummoner", 0.5f);
        }
        
    }

    public void burgerSummoner()
    {
        SmileYourDayTaskList.instance.dg_Heaven += checkString;
        burger(type);
    }

    public void checkString(string apple)
    {
        if(apple == mess)
            CommunicateToServerRpc();
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
        mess = message;
        SmileYourDayTaskList.instance.UpdateGameTask(message, 1);
    }
    [Rpc(SendTo.Everyone, InvokePermission = RpcInvokePermission.Everyone)]
    public void CommunicateToServerRpc()
    {
        Debug.Log("does the client print this?");
        lockedIn = true;
        GetComponent<Image>().color = Color.black;
    }
    
}
