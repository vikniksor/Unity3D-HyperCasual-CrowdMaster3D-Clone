using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BrokenState : State
{
    [SerializeField] private float _fallDistance;

    public event UnityAction Died;

    public void ApplyDamage(Rigidbody attachedBody, float force)
    {
        // Animator.SetTrigger("fall");  // uncomment when add animation
        Vector3 direction = (transform.position - attachedBody.position);
        direction.y = 0;
        Rigidbody.AddForce(direction.normalized * force, ForceMode.Impulse);
    }


    private void FixedUpdate()
    {
        Ray ray = new Ray(transform.position + Vector3.up, Vector3.down);
        if (Physics.Raycast(ray, _fallDistance) == false)
        {
            Rigidbody.constraints = RigidbodyConstraints.None;
            Died?.Invoke();
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (enabled == false)
        {
            return;
        }
        if (other.TryGetComponent(out IDamageable damageable))
        {
            damageable.ApplyDamage(Rigidbody, Rigidbody.velocity.magnitude);
        }
    }
}
