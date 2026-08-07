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
        }
    }

    public void Update()
    {
        //testing
        if(Input.GetKeyDown(KeyCode.N))
        {
            try
            {
                SmileYourDayTaskList.instance.hackerDistractionLocation = transform.right * 5;
                HackGuard(nearbyGuards[0]);
            }
            catch { }
        }
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
        }
    }
}
