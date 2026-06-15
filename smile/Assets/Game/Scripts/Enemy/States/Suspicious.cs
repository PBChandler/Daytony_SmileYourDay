using UnityEngine;
using System.Collections.Generic;

public class Suspicious : EnemyState
{
    [SerializeField] float chaseSpeed;
    [SerializeField] List<EncounterDialog> possibleDialogs = new List<EncounterDialog>();
    SphereCollider talk;
    bool caught = false;
    public override void OnEnterState()
    {
        // will eventually be simplified when we have a clearer distinction between runner and hacker
        // also will be moved to EnemyState
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (runnerRef == null)
            {
                runnerRef = o;
                continue;
            }
            if (Vector3.Distance(transform.position, o.transform.position) < Vector3.Distance(transform.position, runnerRef.transform.position))
                runnerRef = o;
        }
        talk = GetComponent<SphereCollider>();
        talk.enabled = true;
        agent.speed = chaseSpeed;
        agent.angularSpeed = 500;
        agent.SetDestination(runnerRef.transform.position);
    }

    public override void UpdateState()
    {
        // should probably do something abt this
        if (!caught)
            agent.SetDestination(runnerRef.transform.position);
        //if (Vector3.Distance(machine.transform.position, runnerRef.transform.position) < 3)
        //    machine.ChangeState("Idle");
    }

    public override void OnExitState()
    {
        Debug.Log("I am exiting the Suspicious state");
        talk.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("are you who I'm looking for?");
        if (other.tag != "Player")
            return;
        Debug.Log("IT IS YOU IDIOT !!");
        caught = true;

        other.transform.parent.GetComponent<FirstPersonController>().DisplayDialog(possibleDialogs[Random.Range(0, possibleDialogs.Count - 1)]);
    }
}
