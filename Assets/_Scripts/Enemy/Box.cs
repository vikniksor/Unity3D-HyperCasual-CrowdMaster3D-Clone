using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IDamageable
{
    public bool ApplyDamage(Rigidbody rigidbody, float force)
    {
        Debug.Log("I`m the box.");
        return false;
    }
}
