using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SquawkSubpageManager : MonoBehaviour
{
    public List<GameObject> subpages;
    public Squawkr_ProfileReader profileReader;
    public void SetPages(int pageIndex)
    {
        for(int i = 0; i < subpages.Count; i++)
        {
            if(pageIndex == i)
                subpages[i].SetActive(true);
            else
                subpages[i].SetActive(false);
        }
    }

    public void SetPageVariable(SquawkrProfileScriptableObject prof)
    {
        profileReader.profile = prof;
    }
}
