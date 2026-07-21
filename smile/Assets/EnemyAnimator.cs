using Unity.Netcode.Components;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimator : MonoBehaviour
{
    public EnemyStateMachine esm;
    public AnimationClip idle, walking, talking;
    public NetworkAnimator anim;
    public NavMeshAgent agn;

    public Suspicious lash;
    public bool LockedIn;
    public void Start()
    {
        lash = GetComponent<Suspicious>();
         //esm.dg_OnStateChanged += CheckState;
    }

    public void CheckState()
    {
        if(esm.currentState.name == "Idle")
        {
            anim.Animator.SetFloat("speed", 0.0f);
        }
        else
        {
            anim.Animator.SetFloat("speed", 1.0f);
        }
    }
    public void Update()
    {
       anim.Animator.SetFloat("speed", agn.velocity.magnitude);
       bool talking = lash.fpc.caught;
       if(talking && !LockedIn)
       {
        LockedIn = true;
            anim.Animator.SetBool("isTalking", true);
            anim.Animator.SetFloat("suspiciousmeter", Random.Range(0, 1f));
        }
        else if(!talking)
        {
            LockedIn = false;
             anim.Animator.SetBool("isTalking", false);
        }

    }
}
