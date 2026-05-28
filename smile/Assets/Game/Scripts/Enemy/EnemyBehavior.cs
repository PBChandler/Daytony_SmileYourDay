using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyStateMachine))]
public class EnemyBehavior : MonoBehaviour
{
    EnemyStateMachine stateMachine;
    int suspicionLevel;
    NavMeshAgent agent;

    void Start()
    {
        stateMachine = GetComponent<EnemyStateMachine>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (suspicionLevel > 10)
            stateMachine.ChangeState("Suspicious");
    }

    public void AddSuspicion(int sussy)
    {
        suspicionLevel += sussy;
    }

}
