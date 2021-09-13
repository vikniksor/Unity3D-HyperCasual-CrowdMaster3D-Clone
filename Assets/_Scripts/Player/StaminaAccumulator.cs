using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaAccumulator : MonoBehaviour
{
    [SerializeField] private float _accumulationTime;

    private float _staminaValue;

    public void StartAccumulate()
    {
        _staminaValue = 0;
    }


    private void Update()
    {
        _staminaValue += Time.deltaTime;
    }

    public void GetAbility()
    {
        if (_staminaValue > _accumulationTime)
        {
            Debug.Log("Ultimate");

        }

        Debug.Log("Attack");
    }
}
