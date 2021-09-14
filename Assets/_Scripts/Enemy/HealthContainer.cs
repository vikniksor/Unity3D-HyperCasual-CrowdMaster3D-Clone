using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthContainer : MonoBehaviour
{
    [SerializeField] private int _health;

    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;

    public void TakeDamage(int value)
    {
        _health -= value;
        if (_health <= 0)
        {
            _health = 0;
            Died?.Invoke();
        }

        HealthChanged?.Invoke(_health);
    }
}
