using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class Idle : EnemyState
{
    Vector3 randomPos;
    NavMeshPath path;
    public override void OnEnterState()
    {
        Debug.Log("I am entering the Idle state");
        int infinitePrevention = 0;
        stateTimer = Random.Range(10, 60);
        do
        {
            randomPos = Random.insideUnitCircle * stateTimer * .5f;
            randomPos = new Vector3(randomPos.x, transform.position.y, randomPos.y);
            infinitePrevention++;
        }
        while (!agent.CalculatePath(randomPos, agent.path) || infinitePrevention > 5);
    }
    public override void UpdateState()
    {
        stateTimer--;

        if (stateTimer == 0)
            machine.ChangeState("Idle");
    }

    public override void OnExitState()
    {
        Debug.Log("I am exiting the Idle state");
    }
}
