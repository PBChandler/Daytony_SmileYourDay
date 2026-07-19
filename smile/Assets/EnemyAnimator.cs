using Unity.Netcode.Components;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimator : MonoBehaviour
{
    public EnemyStateMachine esm;
    public AnimationClip idle, walking, talking;
    public NetworkAnimator anim;
    public NavMeshAgent agn;
    public void Start()
    {
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
    }
}
