using UnityEngine;
using UnityEngine.Networking;
using Netcode;
using Unity.Netcode.Components;
public class RunnerAnimator : MonoBehaviour
{
    public Rigidbody player;
    public  NetworkAnimator myAnimator;
    public void Update()
    {
        myAnimator.Animator.SetFloat("speed", player.linearVelocity.magnitude);
    }
}
