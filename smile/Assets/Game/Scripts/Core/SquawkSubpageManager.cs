using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SquawkSubpageManager : MonoBehaviour
{
    public List<GameObject> subpages;

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
}
