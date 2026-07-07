using UnityEngine;
using UnityEngine.Networking;
using Netcode;
using Unity.Netcode.Components;
public class RunnerAnimator : MonoBehaviour
{
    public Rigidbody player;
    public FirstPersonController fpc;
    public  NetworkAnimator myAnimator;
    public playerAnimationDetacher pad;
    public Vector3 basicoffset;

    public void Start()
    {
        basicoffset = pad.offset;
    }
    public void Update()
    {
        myAnimator.Animator.SetFloat("speed", player.linearVelocity.magnitude);
        myAnimator.Animator.SetBool("isCrouching", fpc.isCrouched);
    }
}
