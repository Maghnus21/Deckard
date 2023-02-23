using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHitbox : MonoBehaviour
{
    public Health health;

    //  To be used for critical spot/head bones for applying multiplicative damage 
    //  Currently works, need to update Health.cs to not add this script to existing bone game object containing this script
    public float damage_multi = 1f;

    public void OnRaycastHit(float damage, Vector3 impact_direction, Rigidbody hit_rb)
    {
        health.ReceiveDamage(damage * damage_multi, impact_direction, hit_rb);
    }

    public void ExplosiveHit(float damage, Vector3 detonation_location, float explosion_force, float explosion_radius, float explosion_upforce)
    {
        health.ReceiveExplosiveDamage(damage, detonation_location, explosion_force, explosion_radius, explosion_upforce);
    }
}
