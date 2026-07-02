using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class squawkr_profilepreview : MonoBehaviour
{
    public Image PerfectCell;
    public TextMeshProUGUI NamekName;

    public SquawkSubpageManager ofDaysOfYore;

    public SquawkrProfileScriptableObject crank;

    public void SetCell(SquawkrProfileScriptableObject yank)
    {
        PerfectCell.color = Color.white;
        NamekName.text = yank.DisplayName+"";
        PerfectCell.sprite = yank.profilePicture;
        crank = yank;
    }

    public void SetCellEmpty()
    {
        NamekName.text = "";
        PerfectCell.color = Color.clear;
    }

    public void OnProfileClicked()
    {
        ofDaysOfYore.profileReader.profile = crank;
        ofDaysOfYore.SetPages(4);
    }
}
