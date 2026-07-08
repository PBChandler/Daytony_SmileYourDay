using System.Collections.Generic;
using System.Linq;
using Steamworks;
using Steamworks.ServerList;
using UnityEngine;

public class SteamAccountsManager : MonoBehaviour
{
    public List<UI_SteamAccount> toriels = new List<UI_SteamAccount>();
    public List<Steamworks.Friend> friends = new List<Friend>();

    public int basic = 0;
    void Start()
    {
        Invoke("Setup", 0.5f);
    }

    public void Setup()
    {
        var burger = SteamFriends.GetFriends();
        friends = burger.ToList<Friend>();
        for(int i = 0; i < toriels.Count; i++)
        {
            try
            {
                toriels[i].meRightNow = friends[basic+i];
            toriels[i].Carbomb();
            }catch{}

            
        }
    }

    public void ProgressPage()
    {
        basic += 5;
        SetPage();
    }

    public void RegressPage()
    {
        if(basic - 5 >= 0)
        {
            basic -= 5;
        }
        SetPage();
    }
    public void SetPage()
    {
        Setup();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
