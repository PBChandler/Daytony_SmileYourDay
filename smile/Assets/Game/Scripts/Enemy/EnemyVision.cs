using System.Collections;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] LayerMask sightMask;
    EnemyBehavior behavior;
    FirstPersonController fpc;
    Ray sightCast;

    public void Awake()
    {
        behavior = transform.parent.GetComponent<EnemyBehavior>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player")
            return;

        fpc = other.transform.parent.GetComponent<FirstPersonController>();

        sightCast.origin = behavior.transform.position;
        sightCast.direction = (other.transform.position - sightCast.origin).normalized;
        if (Physics.Raycast(sightCast, out RaycastHit hit, 8, sightMask))
        {
            if (hit.collider.tag == "Player")
            {
                if (!fpc.isCrouched) behavior.AddSuspicion(10 - Mathf.FloorToInt(hit.distance), .5f);

                else if (hit.distance < 4) behavior.AddSuspicion(8 - Mathf.FloorToInt(hit.distance), 1);
            }
        }
    }
}
