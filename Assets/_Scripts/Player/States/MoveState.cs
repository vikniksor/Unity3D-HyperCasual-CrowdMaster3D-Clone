using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : PlayerState
{
    [SerializeField] private StaminaAccumulator _staminaAccumulator;
    [SerializeField] private PlayerControl _playerControl;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _speedRatio;



    private void OnEnable()
    {
        _playerControl.DirectionChange += OnDirectionChange;
        _staminaAccumulator.StartAccumulate();
    }

    private void OnDisable()
    {
        _playerControl.DirectionChange -= OnDirectionChange;
    }


    private void OnDirectionChange(Vector2 direction)
    {
        Rigidbody.velocity = new Vector3(direction.x, 0, direction.y) * _speedRatio;

        if (Rigidbody.velocity.magnitude > _maxSpeed)
        {
            Rigidbody.velocity *= _maxSpeed / Rigidbody.velocity.magnitude;
        }

        if (Rigidbody.velocity.magnitude != 0)
        {
            Rigidbody.MoveRotation(Quaternion.LookRotation(Rigidbody.velocity, Vector3.up));
        }
    }
}
