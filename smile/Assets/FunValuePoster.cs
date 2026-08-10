using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class FunValuePoster : MonoBehaviour
{
    


    public List<materialTuple> tmats;
    public bool missingNo;
    public void Start()
    {
        SmileYourDayTaskList.instance.dg_onFunValueChanged += Check;
        Check(SmileYourDayTaskList.instance.funValue.Value);
    }

    public void Check(int newValue)
    {
        foreach(materialTuple mal in tmats)
        {
            if (newValue < mal.maxRange && newValue > mal.minRange)
            {
                GetComponent<MeshRenderer>().material = mal.posterVariant;
            }
        }
    }

    public void OnDestroy()
    {
        SmileYourDayTaskList.instance.dg_onFunValueChanged -= Check;
    }
    public void Update()
    {
        if(((Input.GetKeyDown(KeyCode.Alpha9) && Input.GetKeyDown(KeyCode.Alpha1)))) //just gonna leave this in the final build cos what the hell are you doing to press 1 and 9 at the same time lol
        {
            SmileYourDayTaskList.instance.funValue.Value = Random.Range(0, 100);
            SmileYourDayTaskList.instance.dg_onFunValueChanged(SmileYourDayTaskList.instance.funValue.Value);
        }
    }
}
[System.Serializable]
public struct materialTuple
{
    public Material posterVariant;
    public int minRange, maxRange;
}