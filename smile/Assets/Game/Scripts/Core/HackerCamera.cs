using System.Collections.Generic;
using UnityEngine;

public class HackerCamera : MonoBehaviour
{
    public string camSystemID;
    public Transform cameraOutlook;
    public GameObject smosh;
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

    public void Update()
    {
        smosh.SetActive(kidLogic.camIsActive);
    }
    public void HackWithChild(EnemyStateMachine guard)
    {
        SmileYourDayTaskList.instance.hackerDistractionLocation = kidLogic.guardsStandNearHere.transform.position;
        kidLogic.HackGuard(guard);
    }
    
    public void setCustomActive(bool aBool)
    {
        kidLogic.camIsActive = aBool;
        SmileYourDayTaskList.instance.ActiveHackerCameraInWorld = kidLogic;
    }

    
}
