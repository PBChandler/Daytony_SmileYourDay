using System.Collections.Generic;
using UnityEngine;

public class HCK_TabSystem : MonoBehaviour
{
    public delegate void OnTabClicked(int tabID);
    public OnTabClicked dg_OnTabClicked;

    public void SwitchTab(int tabID)
    {
        dg_OnTabClicked.Invoke(tabID);
    }
    
    public void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            UI_HCK_Tab garfield = transform.GetChild(i).GetComponent<UI_HCK_Tab>();
            garfield.MainSystem = this;
            dg_OnTabClicked += garfield.TabSwitchReaction;
        }
    }

}
