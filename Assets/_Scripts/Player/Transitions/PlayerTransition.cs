using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerTransition : MonoBehaviour
{
    [SerializeField] private PlayerState _targetState;

    public PlayerState TargetState => _targetState;
    public bool NeedTransit { get; protected set; }

    private void OnEnable()
    {
        NeedTransit = false;
        Enable();
    }

    public abstract void Enable();
}
