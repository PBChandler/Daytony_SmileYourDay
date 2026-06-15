using UnityEngine;
using UnityEngine.AI;
using System.Collections;

[RequireComponent(typeof(EnemyStateMachine))]
public class EnemyBehavior : MonoBehaviour
{
    EnemyStateMachine stateMachine;
    int suspicionLevel;
    NavMeshAgent agent;
    bool susCooldown;

    void Start()
    {
        stateMachine = GetComponent<EnemyStateMachine>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (suspicionLevel > 10 && stateMachine.currentState != stateMachine.GetStateFromName("Suspicious"))
            stateMachine.ChangeState("Suspicious");
    }
    IEnumerator SuspicionTick(float sec)
    {
        susCooldown = true;
        yield return new WaitForSeconds(1);
        susCooldown = false;
    }

    public void AddSuspicion(int sussy, float cooldownTime)
    {
        if (susCooldown)
            return;
        suspicionLevel += sussy;
        StartCoroutine(SuspicionTick(cooldownTime));
    }

}
