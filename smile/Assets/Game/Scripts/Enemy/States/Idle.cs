using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Idle : EnemyState
{
    Vector3 randomPos;
    bool counting;

    public override void OnEnterState()
    {
        Debug.Log("I am entering the Idle state");
        int infinitePrevention = 0;
        stateTimer = Random.Range(60, 300);
        randomPos = Random.insideUnitCircle.normalized;
        transform.rotation = Quaternion.Euler(new Vector3(randomPos.x, transform.position.y, randomPos.y) * 360);
        //do
        //{
        //    randomPos = Random.insideUnitCircle * stateTimer * .5f;
        //    randomPos = new Vector3(randomPos.x, transform.position.y, randomPos.y);
        //    infinitePrevention++;
        //}
        //while (!agent.CalculatePath(randomPos, agent.path) || infinitePrevention > 5);
    }
    public override void UpdateState()
    {
        transform.position += transform.forward * .01f;

        if (!counting)
            StartCoroutine(Countdown());

        if (stateTimer == 0)
            machine.ChangeState("Idle");
    }

    IEnumerator Countdown()
    {
        counting = true;
        stateTimer--;
        yield return new WaitForEndOfFrame();
        counting = false;
    }

    public override void OnExitState()
    {
        Debug.Log("I am exiting the Idle state");
    }
}
