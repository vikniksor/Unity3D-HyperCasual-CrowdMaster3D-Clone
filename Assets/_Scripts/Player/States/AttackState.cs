using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackState : PlayerState
{
    [SerializeField] private StaminaAccumulator _staminaAccumulator;

    private Ability _currentAbility;

    public event UnityAction CollisionDetected;
    public event UnityAction AbilityEnded;

    private void OnEnable()
    {
        _currentAbility = _staminaAccumulator.GetAbility();
    }
}
