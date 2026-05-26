using UnityEngine;
using UnityEngine.UIElements;

public class Suspicious : EnemyState
{
    GameObject runnerRef;
    public override void OnEnterState()
    {
        runnerRef = GameObject.FindGameObjectWithTag("Runner");
        machine.transform.LookAt(runnerRef.transform.position);
    }

    public override void UpdateState()
    {
        machine.transform.position += machine.transform.forward * 2;
        if (Vector3.Distance(machine.transform.position, runnerRef.transform.position) < 3)
            machine.ChangeState("Idle");
    }

    public override void OnExitState()
    {
        Debug.Log("I am exiting the Suspicious state");
    }
}
