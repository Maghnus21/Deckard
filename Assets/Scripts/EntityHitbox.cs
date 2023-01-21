using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHitbox : MonoBehaviour
{
    public Health health;

    public void OnRaycastHit(float damage, Vector3 impact_direction)
    {
        health.ReceiveDamage(damage, impact_direction);
    }
}
