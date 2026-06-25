using UnityEngine;
using UnityEngine.AI;
using System.Collections;

[RequireComponent(typeof(EnemyStateMachine))]
public class EnemyBehavior : MonoBehaviour
{
    EnemyStateMachine stateMachine;
    public int suspicionLevel;
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
        //Debug.Log("Current Suspicion is " + suspicionLevel);
        if (suspicionLevel > 10 && stateMachine.currentState == stateMachine.GetStateFromName("Idle"))
            stateMachine.ChangeState("Suspicious");
    }
    IEnumerator SuspicionTick(float sec)
    {
        susCooldown = true;
        yield return new WaitForSeconds(sec);
        susCooldown = false;
    }

    public void AddSuspicion(int setting, float cooldownTime)
    {
        if (susCooldown)
            return;
        suspicionLevel += setting;
        StartCoroutine(SuspicionTick(cooldownTime));
    }
    
    public void SetSuspicion(int setting, float cooldownTime, bool bypassCooldown)
    {
        if (bypassCooldown ? false : susCooldown)
            return;
        suspicionLevel = setting;
        StartCoroutine(SuspicionTick(cooldownTime));
    }
}
