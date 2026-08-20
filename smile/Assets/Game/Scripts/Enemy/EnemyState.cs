using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyState : MonoBehaviour
{
    [HideInInspector] public bool isCurrentState = false;
    public EnemyStateMachine machine;
    protected EnemyManager manager;
    protected int stateTimer;
    protected NavMeshAgent agent;
    protected GameObject runnerRef;
    public GameObject _runnerRef { get { return runnerRef; } set { runnerRef = value; } }
    public EnemyState prevState;
    protected SphereCollider talk;
    protected EnemyVision sight;

    protected EnemyBehavior enemyB;
    public int suspicionLevel => enemyB.suspicionLevel;

    private void Awake()
    {
        machine = GetComponent<EnemyStateMachine>();
        agent = GetComponent<NavMeshAgent>();
        enemyB = GetComponent<EnemyBehavior>();
        talk = GetComponent<SphereCollider>();
        sight = GetComponentInChildren<EnemyVision>();
        manager = transform.parent.GetComponent<EnemyManager>();

        // will eventually be simplified when we have a clearer distinction between runner and hacker
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Runner"))
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

    public void DecreaseStateTime() => stateTimer--;

    public virtual void PassInfo<T>(T[] args) // probably impractical but whatever
    {

    }
    public virtual void PassInfo<T>(T arg)
    {

    }
}
