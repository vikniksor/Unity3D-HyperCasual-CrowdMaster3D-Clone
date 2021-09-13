using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HandAbility : Ability
{
    [SerializeField] private float _attackForce;
    [SerializeField] private float _usefullTime;

    private AttackState _attackState;
    private Coroutine _coroutine;

    public override event UnityAction AbilityEnded;

    public override void UseAbility(AttackState attackState)
    {
        if (_coroutine != null)
        {
            Reset();
        }

        _attackState = attackState;

        _attackState.CollisionDetected += OnPlayerAttack;
    }

    private void OnPlayerAttack()
    {

    }

    private IEnumerator Attack(AttackState state)
    {
        float time = _usefullTime;

        while (time > 0)
        {
            state.Rigidbody.velocity = state.Rigidbody.velocity.normalized * _attackForce;
            time -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        Reset();
        AbilityEnded?.Invoke();
    }

    private void Reset()
    {
        _attackState.Rigidbody.velocity = Vector3.zero;
        _attackState.StopCoroutine(_coroutine);
        _coroutine = null;
        _attackState.CollisionDetected -= OnPlayerAttack;
    }
}
