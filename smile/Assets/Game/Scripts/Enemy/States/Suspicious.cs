using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.XR;

public class Suspicious : EnemyState
{
    [SerializeField] float chaseSpeed;
    [SerializeField] List<EncounterDialog> possibleDialogs = new List<EncounterDialog>();
    public FirstPersonController fpc;
    public bool caught = false;

    public override void OnEnterState()
    {
        Debug.Log("Entering the suspicious state");

        talk.enabled = true;
        agent.speed = chaseSpeed;
        agent.angularSpeed = 500;
        agent.SetDestination(runnerRef.transform.position);
        caught = false;
        agent.isStopped = false;
        stateTimer = 180;
    }

    public override void UpdateState()
    {
        // should probably do something abt this
        //if (!caught)
        //    agent.SetDestination(runnerRef.transform.position);
        if (stateTimer <= 0)
            machine.ChangeState("Searching");
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
                machine.ChangeState("Alarmed");
                break;
            case 1:
                enemyB.SetSuspicion(5, 3, true);
                machine.ChangeState("Idle");
                enemyB.AddSuspicion(0, 3);
                sight.SightCooldown(3);
                talk.enabled = false;
                break;
            case 0:
                enemyB.SetSuspicion(0, 3, true);
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
        if (!isCurrentState)
            return;

        if (caught)
            return;

        if (other.tag != "Player")
            return;

        caught = true;

        agent.isStopped = true;
        sight.SetSight(false);

        fpc = other.transform.parent.GetComponent<FirstPersonController>();
        fpc.DisplayDialog(possibleDialogs[Random.Range(0, possibleDialogs.Count - 1)], this);
        fpc.currentResponse += HandleResponse;
        talk.enabled = false;
    }
}
