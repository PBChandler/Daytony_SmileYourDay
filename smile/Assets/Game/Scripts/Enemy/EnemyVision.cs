using System.Collections;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] LayerMask sightMask;
    EnemyBehavior behavior;
    Ray sightCast;

    public void Awake()
    {
        behavior = transform.parent.GetComponent<EnemyBehavior>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player")
            return;

        sightCast.origin = behavior.transform.position;
        sightCast.direction = (other.transform.position - sightCast.origin).normalized;
        if (Physics.Raycast(sightCast, out RaycastHit hit, 8, sightMask))
        {
            if (hit.collider.tag == "Player")
                behavior.AddSuspicion(3);
        }
    }

}
