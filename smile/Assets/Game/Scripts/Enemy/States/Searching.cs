using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Searching : EnemyState
{
    Vector3[] rotationValues = new Vector3[3];

    Vector3 origin;
    int rotationIndex;
    float lerpValue;
    bool isPaused;

    public override void OnEnterState()
    {
        Debug.Log("Now entering. Searching State. Doors will open on the left.");
        sight.SetSight(true);

        rotationValues[0] = new Vector3(transform.rotation.x, 35, transform.rotation.z);
        rotationValues[1] = new Vector3(transform.rotation.x, -35, transform.rotation.z);
        rotationValues[2] = new Vector3(transform.rotation.x, 180, transform.rotation.z);
        origin = transform.rotation.eulerAngles;

        rotationIndex = 0;

        agent.isStopped = true;
    }

    public override void UpdateState()
    {
        if (isPaused)
            return;

        switch (rotationIndex)
        {
            case 0:
                transform.rotation = Quaternion.Euler(Vector3.Lerp(origin, rotationValues[0], lerpValue));
                break;
            case 1:
                transform.rotation = Quaternion.Euler(Vector3.Lerp(rotationValues[0], rotationValues[1], lerpValue));
                break;
            case 2:
                transform.rotation = Quaternion.Euler(Vector3.Lerp(rotationValues[1], rotationValues[2], lerpValue));
                break;
            case 3:
                enemyB.suspicionLevel = 0;
                machine.ChangeState("Idle");
                break;
            default:
                break;
        }
        if (lerpValue >= 1)
        {
            lerpValue = 0;
            rotationIndex++;
            StartCoroutine(RotatePause());
        }
        lerpValue += Time.deltaTime;
    }

    IEnumerator RotatePause()
    {
        isPaused = true;
        yield return new WaitForSeconds(1);
        isPaused = false;
    }

    public override void OnExitState()
    {
        agent.isStopped = false;
    }
}
