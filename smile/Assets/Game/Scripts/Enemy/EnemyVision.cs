using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] LayerMask sightMask;
    EnemyBehavior behavior;
    EnemyStateMachine machine;
    Alarmed alr;
    FirstPersonController fpc;
    NavMeshAgent agent;
    Ray sightCast;
    RaycastHit hit;
    bool canSee = false;
    bool playerInView = false;

    public void Awake()
    {
        behavior = transform.parent.GetComponent<EnemyBehavior>();
        machine = transform.parent.GetComponent<EnemyStateMachine>();
        alr = transform.parent.GetComponent<Alarmed>();
        agent = transform.parent.GetComponent<NavMeshAgent>();
    }

    public IEnumerator SightCooldown(float sec)
    {
        canSee = false;
        yield return new WaitForSeconds(sec);
        canSee = true;
    }

    public void ToggleSight() => canSee = !canSee;
    public void SetSight(bool val) => canSee = val;

    private void FixedUpdate()
    {
        if (!playerInView && machine.currentState == machine.GetStateFromName("Alarmed"))
            alr.DecreaseStateTime();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player")
            return;
        if (!canSee)
            return;

        fpc = other.transform.parent.GetComponent<FirstPersonController>();

        sightCast.origin = behavior.transform.position;
        sightCast.direction = (other.transform.position - sightCast.origin).normalized;
        if (Physics.Raycast(sightCast, out hit, 8, sightMask))
        {
            if (hit.collider.tag == "Player")
            {
                if (machine.currentState == machine.GetStateFromName("Idle"))
                {
                    if (!fpc.isCrouched) behavior.AddSuspicion(10 - Mathf.FloorToInt(hit.distance), .5f);

                    else if (hit.distance < 4) behavior.AddSuspicion(8 - Mathf.FloorToInt(hit.distance), 1);
                }
                else if (machine.currentState == machine.GetStateFromName("Alarmed"))
                {
                    Debug.Log("got eyes");
                    playerInView = true;
                    agent.SetDestination(fpc.transform.position);
                }
                else if (machine.currentState == machine.GetStateFromName("Searching"))
                {
                    Debug.Log("YOU !!!!");
                    machine.ChangeState("Alarmed");
                }
            }
        }
        else if (machine.currentState == machine.GetStateFromName("Alarmed"))
            playerInView = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player")
            return;

        playerInView = false;

        //if (hit.collider != null && hit.collider.tag == "Player")
        //    playerInView = false;
    }
}
