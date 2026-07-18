using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public void SetPlayer()
    {
        foreach (EnemyStateMachine m in GetComponentsInChildren<EnemyStateMachine>())
            m.SetPlayer(GameObject.FindGameObjectWithTag("Player"));
    }
}
