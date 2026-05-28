using UnityEngine;
using UnityEngine.UIElements;

public class Suspicious : EnemyState
{
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
        machine.transform.LookAt(runnerRef.transform.position);
    }

    public override void UpdateState()
    {
        machine.transform.position += machine.transform.forward * .3f;
        if (Vector3.Distance(machine.transform.position, runnerRef.transform.position) < 3)
            machine.ChangeState("Idle");
    }

    public override void OnExitState()
    {
        Debug.Log("I am exiting the Suspicious state");
    }
}
