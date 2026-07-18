using UnityEngine;

public class Distracted : EnemyState
{
    bool changedTarget;

    public override void OnEnterState()
    {
        changedTarget = false;
    }

    public override void PassInfo<T>(T args)
    {
        if (args is not Vector3 r)
        {
            Debug.LogError("Invalid argument! I have nowhere to go.");
            return;
        }
        
        changedTarget = agent.SetDestination(r);
    }

    public override void UpdateState()
    {
        if (!changedTarget)
            return;

        if (agent.remainingDistance <= agent.stoppingDistance)
            machine.ChangeState("Searching");
    }

    public override void OnExitState()
    {
        
    }
}
