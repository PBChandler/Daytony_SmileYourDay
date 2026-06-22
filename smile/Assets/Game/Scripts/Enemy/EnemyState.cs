using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyState : MonoBehaviour
{
    public EnemyStateMachine machine;
    protected int stateTimer;
    protected NavMeshAgent agent;
    protected GameObject runnerRef;
    protected SphereCollider talk;

    protected EnemyBehavior enemyB;
    protected int suspicionLevel
    {
        get => enemyB.suspicionLevel;
        set { enemyB.suspicionLevel = value; }
    }

    private void Awake()
    {
        machine = GetComponent<EnemyStateMachine>();
        agent = GetComponent<NavMeshAgent>();
        enemyB = GetComponent<EnemyBehavior>();
        // will eventually be simplified when we have a clearer distinction between runner and hacker
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


    }
    public abstract void OnEnterState();

    public abstract void UpdateState();

    public abstract void OnExitState();
}
