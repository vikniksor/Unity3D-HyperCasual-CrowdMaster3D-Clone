using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    bool ApplyDamage(Rigidbody rigidbody, float force);
}
