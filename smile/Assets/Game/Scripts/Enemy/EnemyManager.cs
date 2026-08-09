using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public delegate void DangerModeDelegate(bool dMode);
    public event DangerModeDelegate dangerModeTriggered;
    public bool dangerMode = false;

    private void Awake()
    {
        dangerModeTriggered += SetEnemyDanger;
    }

    public void SetPlayer()
    {
        foreach (EnemyStateMachine m in GetComponentsInChildren<EnemyStateMachine>())
            m.SetPlayer(GameObject.FindGameObjectWithTag("Player"));
    }

    public void SetEnemyDanger(bool d)
    {
        EnemyBehavior[] behaviors = GetComponentsInChildren<EnemyBehavior>();

        // check if the value even needs to be changed
        if (behaviors[0].inDangerMode == d)
            return;

        foreach(EnemyBehavior b in behaviors)
            b.inDangerMode = d;

        Debug.LogError("Danger Mode Activated !!!! Get outta there !!!!!");
    }

    public void EnterDangerMode()
    {
        dangerMode = true;
        dangerModeTriggered(dangerMode);
    }

    public void SetDangerMode(bool setting)
    {
        dangerMode = setting;
        dangerModeTriggered(dangerMode);
    }
}
