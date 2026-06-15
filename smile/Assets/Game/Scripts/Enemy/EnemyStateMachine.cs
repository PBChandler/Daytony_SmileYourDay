using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    Dictionary<string, EnemyState> stateDictionary = new Dictionary<string, EnemyState>();
    public EnemyState currentState;
    [HideInInspector] public EnemyBehavior behavior;

    void Start()
    {
        foreach (var state in GetComponents<EnemyState>())
        {
            stateDictionary.Add(state.GetType().ToString(), state);
        }

        behavior = GetComponent<EnemyBehavior>();
        currentState = stateDictionary["Idle"];
        currentState.OnEnterState();
    }

    public void ChangeState(string stateName)
    {
        currentState.OnExitState();
        currentState = stateDictionary[stateName];
        currentState.machine = this;
        currentState.OnEnterState();
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
