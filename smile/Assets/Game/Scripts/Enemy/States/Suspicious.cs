using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.XR;

public class Suspicious : EnemyState
{
    [SerializeField] float chaseSpeed;
    [SerializeField] List<EncounterDialog> possibleDialogs = new List<EncounterDialog>();
    FirstPersonController fpc;
    EnemyVision sight;
    bool caught = false;
    public override void OnEnterState()
    {
        Debug.Log("Entering the suspicious state");
        talk = GetComponent<SphereCollider>();
        sight = GetComponentInChildren<EnemyVision>();

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

    public void HandleResponse(int response)
    {
        switch (response)
        {
            case 2:
                Debug.Log("We are going to kill you.");
                machine.ChangeState("Alarmed");
                break;
            case 1:
                enemyB.SetSuspicion(5, 3);
                machine.ChangeState("Idle");
                enemyB.AddSuspicion(0, 3);
                sight.SightCooldown(3);
                talk.enabled = false;
                break;
            case 0:
                enemyB.SetSuspicion(0, 3);
                machine.ChangeState("Idle");
                enemyB.AddSuspicion(0, 8);
                sight.SightCooldown(8);
                talk.enabled = false;
                break;
            default:
                break;
        }

        fpc.currentResponse -= HandleResponse;

        caught = false;
        agent.isStopped = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (caught)
            return;

        Debug.Log("are you who I'm looking for?");
        if (other.tag != "Player")
            return;
        Debug.Log("IT IS YOU IDIOT !!");
        caught = true;

        agent.isStopped = true;
        sight.SetSight(false);

        fpc = other.transform.parent.GetComponent<FirstPersonController>();
        fpc.DisplayDialog(possibleDialogs[Random.Range(0, possibleDialogs.Count - 1)], this);
        fpc.currentResponse += HandleResponse;
        talk.enabled = false;
    }
}
