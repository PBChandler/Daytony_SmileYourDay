using System.Collections.Generic;
using UnityEngine;

public class HackerCamera : MonoBehaviour
{
    public string camSystemID;
    public Transform cameraOutlook;
    [HideInInspector] public RadioAOE kidLogic;
    public void Start()
    {
        Invoke("builddelay", 0.5f);
        kidLogic = GetComponentInChildren<RadioAOE>();
    }

    public void builddelay()
    {
        SmileYourDayTaskList.instance.hackerCamera.cams.Add(this);
    }

    
    public void setCustomActive(bool aBool)
    {
        kidLogic.camIsActive = aBool;
    }

    
}
