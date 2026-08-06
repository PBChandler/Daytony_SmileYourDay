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
    [SerializeField] bool inSafeZone;
    [HideInInspector] public bool noticedPlayer;
    [HideInInspector] public bool inDangerMode = false;

    void Start()
    {
        stateMachine = GetComponent<EnemyStateMachine>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (suspicionLevel > 10 && stateMachine.currentState == stateMachine.GetStateFromName("Idle") && !inSafeZone)
        {
            if (inDangerMode)
                stateMachine.ChangeState("Alarmed");
            else
                stateMachine.ChangeState("Suspicious");
        }
    }

    IEnumerator SuspicionTick(float sec)
    {
        susCooldown = true;
        if (inDangerMode)
            suspicionLevel = 15;
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
