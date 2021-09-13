using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Animator))]
public class PlayerStateMachine : MonoBehaviour
{
    [SerializeField] private PlayerState _firstState;

    private PlayerState _currentState;
    private Rigidbody _rigidbody;
    private Animator _animator;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }


    private void Start()
    {
        _currentState = _firstState;
        _currentState.Enter(_rigidbody, _animator);

    }


    private void Update()
    {
        if (_currentState == null) return;

        PlayerState nextState = _currentState.GetNextState();
        if (nextState != null)
        {
            Transit(nextState);
        }
    }


    private void Transit(PlayerState nextState)
    {
        if (_currentState != null) { _currentState.Exit(); }

        _currentState = nextState;

        if (_currentState != null) { _currentState.Enter(_rigidbody, _animator); }
        
    }
}
