using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackState : State
{
    [SerializeField] private StaminaAccumulator _staminaAccumulator;

    private Ability _currentAbility;

    public event UnityAction<IDamageable> CollisionDetected;
    public event UnityAction AbilityEnded;

    private void OnEnable()
    {
        //Animator.SetTrigger("attackTrigger");  // uncomment when create an animation for attack.
        _currentAbility = _staminaAccumulator.GetAbility();
        _currentAbility.AbilityEnded += OnAbilityEnded;

        _currentAbility.UseAbility(this);
    }

    private void OnDisable()
    {
        _currentAbility.AbilityEnded -= OnAbilityEnded;
    }

    private void OnAbilityEnded()
    {
        AbilityEnded?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageable damageable))
        {
            CollisionDetected?.Invoke(damageable);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
        {
            CollisionDetected?.Invoke(damageable);
        }
    }


    private void Update()
    {
        
    }
}
