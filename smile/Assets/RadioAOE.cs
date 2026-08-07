using NUnit.Framework;
using UnityEngine;
using System.IO;
using System.Collections.Generic;
public class RadioAOE : MonoBehaviour
{
    public string CamID;
    public Transform guardsStandNearHere;
    public List<EnemyStateMachine> nearbyGuards = new List<EnemyStateMachine>();
    public bool camIsActive;
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            nearbyGuards.Add(other.GetComponent<EnemyStateMachine>());
            SmileYourDayTaskList.instance.toothblue.Initialize(nearbyGuards);
        }
    }

    public void Update()
    {
        //testing
        //if(!SmileYourDayTaskList.instance.hackerQueue)
        //{
        //    SmileYourDayTaskList.instance.guardInQueue = nearbyGuards[0];
        //}
    }
    public void HackGuard(EnemyStateMachine guard)
    {
        guard.ChangeState("Distracted");
        guard.GetStateFromName("Distracted").PassInfo<Vector3>(SmileYourDayTaskList.instance.hackerDistractionLocation);
    }
    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Enemy")
        {
            nearbyGuards.Remove(other.GetComponent<EnemyStateMachine>());
            SmileYourDayTaskList.instance.toothblue.Initialize(nearbyGuards);
        }
    }
}
