using Steamworks;
using UnityEngine;

public class Alarmed : EnemyState
{
    [SerializeField] float alarmedSpd;

    public override void OnEnterState()
    {
        agent.speed = alarmedSpd;
        stateTimer = 180;
        agent.isStopped = false;
        talk.enabled = false;
    }

    public override void UpdateState()
    {
        Debug.Log("stateTimer is " + stateTimer);
        agent.SetDestination(runnerRef.transform.position);
        if (stateTimer <= 0)
        {
            enemyB.SetSuspicion(0, 3);
            machine.ChangeState("Idle");
        }
    }

    public void DecreaseStateTime() => stateTimer--;

    public override void OnExitState()
    {
        
    }
}
