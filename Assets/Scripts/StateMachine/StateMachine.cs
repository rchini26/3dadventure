using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class StateMachine<T> where T : System.Enum 
{
    //key
    public Dictionary<T, StateBase> dictionaryState;
    
    private StateBase _currentState;
    public float timeToStartGame = 1f;

    private void Init()
    {
        dictionaryState = new Dictionary<T, StateBase>();
    }
    
    protected void RegisterStates(T typeEnum, StateBase state)
    {
        dictionaryState = new Dictionary<T, StateBase>();
    }
    
    public void SwitchState(T state)
    {
        if (_currentState != null) _currentState.OnStateExit();
        
        _currentState = dictionaryState[state];
        
        _currentState.OnStateEnter();
    }

    public void Update()
    {
        if (_currentState != null) _currentState.OnStateStay();
    }
}
