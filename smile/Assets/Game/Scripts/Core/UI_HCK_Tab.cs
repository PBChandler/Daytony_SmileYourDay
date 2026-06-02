using UnityEngine;
using TMPro;
public class UI_HCK_Tab : MonoBehaviour
{
    [HideInInspector] public HCK_TabSystem MainSystem; //somewhat decoupled, the TabSystem itself fills out this variable, which requires this script to be it's direct child.
    public int tabID;
    public string Displayname;
    public GameObject pageContents;
    public TextMeshProUGUI tabLabel;

    public void OnEnable()
    {
        tabLabel.text = Displayname;
        CloseTab();
    }
    public void OnClick()
    {
        MainSystem.dg_OnTabClicked(tabID);
    }

    public void TellMasterToSwitchTab()
    {
        MainSystem.SwitchTab(tabID);
    }
    public void TabSwitchReaction(int otherTab)
    {
        if(otherTab == tabID)
        {
            pageContents.SetActive(true);
        }
        else
        {
            CloseTab();
        }
        
    }

    public void OpenTab()
    {
        pageContents.SetActive(true);
    }
    public void CloseTab()
    {
        //making this a function cos I know there's gonna be something dumb about just disabling the UI gameobject and I'm going to have to make a more sophisticated thign. Calling it now, 6/2/2026
        pageContents.SetActive(false);
    }
}
