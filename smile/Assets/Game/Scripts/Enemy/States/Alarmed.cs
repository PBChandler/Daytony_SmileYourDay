using Steamworks;
using System.Collections;
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
        sight.SetSight(true);
        StartCoroutine(DelayCatch());
    }

    public override void UpdateState()
    {
        Debug.Log("stateTimer is " + stateTimer);
        if (stateTimer <= 0)
        {
            enemyB.SetSuspicion(0, 3, true);
            machine.ChangeState("Searching");
        }
    }
    
    IEnumerator DelayCatch()
    {
        yield return new WaitForSeconds(1);
        talk.enabled = true;
    }

    public override void OnExitState()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
            return;
        if (!isCurrentState) // bandaid
            return;


        // GAME OVER STATE !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        other.transform.parent.position = Vector3.zero;
    }
}
