using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyState : MonoBehaviour
{
    public EnemyStateMachine machine;
    protected int stateTimer;
    protected NavMeshAgent agent;
    private void Awake()
    {
        machine = GetComponent<EnemyStateMachine>();
        agent = GetComponent<NavMeshAgent>();
    }
    public abstract void OnEnterState();

    public abstract void UpdateState();

    public abstract void OnExitState();
}
