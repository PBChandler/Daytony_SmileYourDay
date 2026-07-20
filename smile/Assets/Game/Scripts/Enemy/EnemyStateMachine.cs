using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    Dictionary<string, EnemyState> stateDictionary = new Dictionary<string, EnemyState>();
    public EnemyState currentState;
    [HideInInspector] public EnemyBehavior behavior;

    public delegate void OnStateChanged();
    public OnStateChanged dg_OnStateChanged;

    void Start()
    {
        foreach (var state in GetComponents<EnemyState>())
        {
            stateDictionary.Add(state.GetType().ToString(), state);
            state.enabled = false;
        }

        behavior = GetComponent<EnemyBehavior>();
        currentState = stateDictionary["Idle"];
        currentState.OnEnterState();
    }

    public void SetPlayer(GameObject player)
    {
        foreach (EnemyState s in stateDictionary.Values)
            s._runnerRef = player;
    }

    public void ChangeState(string stateName)
    {
        currentState.OnExitState();
        currentState.enabled = false;
        currentState.isCurrentState = false;
        stateDictionary[stateName].prevState = currentState;
        currentState = stateDictionary[stateName];
        currentState.enabled = true;
        currentState.isCurrentState = true;
        currentState.machine = this;
        currentState.OnEnterState();
        dg_OnStateChanged?.Invoke();
    }

    public EnemyState GetStateFromName(string stateName)
    {
        if (stateDictionary.ContainsKey(stateName))
            return stateDictionary[stateName];

        Debug.LogError("State does not exist!");
        return null;
    }

    void FixedUpdate()
    {
        currentState.UpdateState();
    }

}
