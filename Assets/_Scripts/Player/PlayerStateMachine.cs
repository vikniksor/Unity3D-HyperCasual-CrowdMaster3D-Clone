using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody), typeof(Animator), typeof(HealthContainer))]
public class PlayerStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private State _currentState;
    private Rigidbody _rigidbody;
    private Animator _animator;
    private HealthContainer _health;

    public event UnityAction Damaged;

    private void OnEnable()
    {
        _health.Died += OnDied;
    }

    private void OnDisable()
    {
        _health.Died -= OnDied;
    }

    private void OnDied()
    {
        enabled = false;
        // _animator.SetTrigger("broken");  // uncomment when create animation
    }


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _health = GetComponent<HealthContainer>();
    }


    private void Start()
    {
        _currentState = _firstState;
        _currentState.Enter(_rigidbody, _animator);

    }


    private void Update()
    {
        if (_currentState == null) return;

        State nextState = _currentState.GetNextState();
        if (nextState != null)
        {
            Transit(nextState);
        }
    }


    private void Transit(State nextState)
    {
        if (_currentState != null) { _currentState.Exit(); }

        _currentState = nextState;

        if (_currentState != null) { _currentState.Enter(_rigidbody, _animator); }
        
    }

    public void ApplyDamage(float damage)
    {
        Damaged?.Invoke();
        _health.TakeDamage((int)damage);
    }
}

