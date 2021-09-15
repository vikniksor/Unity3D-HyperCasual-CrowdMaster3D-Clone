using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    [SerializeField] private EnemyTransition[] _transitions;

    public Rigidbody Rigidbody { get; private set; }
    public PlayerStateMachine Player { get; private set; }
    protected Animator Animator { get; private set; }  // get is protected.


    public void Enter(Rigidbody rigidbody, Animator animator, PlayerStateMachine player)
    {
        if (enabled == false)
        {
            Rigidbody = rigidbody;
            Animator = animator;
            Player = player;

            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(Player);
            }
        }
    }

    public void Exit()
    {
        if (enabled == true)
        {
            foreach (var transition in _transitions)
            {
                transition.enabled = false;   
            }

            enabled = false;
        }
    }

    public EnemyState GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
            {
                return transition.TargetState;
            }
        }

        return null;
    }
}
