using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class Idle : EnemyState
{
    [SerializeField] bool stationary;
    Vector3 origin;
    [SerializeField] List<Vector3> destinations = new List<Vector3>();
    int destinationIndex = 1;
    bool counting;
    bool backwards;

    public override void OnEnterState()
    {
        Debug.Log("I am entering the Idle state");
        stateTimer = Random.Range(60, 300);
        if (!stationary)
        {
            try
            {
                agent.SetDestination(destinations[1]);
            }
            catch
            {
                Debug.LogError(name + " is missing its movement path and is not marked as stationary!");
            }
            backwards = false;
            destinationIndex = 1;
        }
    }

    public override void UpdateState()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            if (destinationIndex == 0)
            {
                machine.ChangeState("Idle");
                return;
            }

            if (destinations.Count == destinationIndex)
                backwards = true;

            if (backwards)
            {
                destinationIndex--;
                agent.SetDestination(destinations[destinationIndex]);
            }
            else
            {
                agent.SetDestination(destinations[destinationIndex]);
                destinationIndex++;
            }
        }

        //if (!counting)
        //    StartCoroutine(Countdown());

        //if (stateTimer == 0)
        //    machine.ChangeState("Idle");
    }

    IEnumerator Countdown()
    {
        counting = true;
        stateTimer--;
        yield return new WaitForEndOfFrame();
        counting = false;
    }

    public override void OnExitState()
    {
        Debug.Log("I am exiting the Idle state");
    }
}
