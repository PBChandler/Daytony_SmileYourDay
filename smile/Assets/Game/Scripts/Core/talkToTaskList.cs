using System.Threading.Tasks;
using Steamworks;
using UnityEngine;

public class talkToTaskList : MonoBehaviour
{
    public UI_SteamAccount possiblyMe;
    public int type = 0; //0 = runner 1 = hacker
    void Start()
    {
        if (possiblyMe != null)
        {
            burger(type);
        }
    }

    public async void burger(int a)
    {
        await setPortrait(a);
    }
    public async Task setPortrait(int mode)
    {
        switch (mode)
        {
            case 0:
                await possiblyMe.Populate(SmileYourDayTaskList.instance.client.AccountId);
                break;
            case 1:
                await possiblyMe.Populate(SmileYourDayTaskList.instance.host.AccountId);
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateTaskList(string message)
    {
        SmileYourDayTaskList.instance.UpdateGameTask(message, 1);
    }
}
