using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Enemy enemy_type;                    //  contains data etc health
    Ragdoll ragdoll;                            //  controlls ragdoll effects for entity

    public float impact_force = 20f;            //  force applied to entity when hit with killing bullet

    public float health;

    /// <summary>
    /// if assigned as true, gameObject mass included in ragdoll physics. assigned as false and ragdoll mass is ignored. default is true
    /// </summary>
    public bool death_force_mode = true;

    void Awake()
    {
        health = enemy_type.health;

        ragdoll = GetComponent<Ragdoll>();

        CreateEntityRagdoll();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Function called when bone gameObject containing script EntityHitbox hit with bullet.
    /// </summary>
    /// <param name="amount">passes damage amount</param>
    /// <param name="impact_direction">the direction of impact received from bullet prefab ray</param>
    /// <param name="hit_rb">bone gameObject with rigidbody that was hit by RaycastHit passed via hit.rigidbody</param>
    public void ReceiveDamage(float amount, Vector3 impact_direction, Rigidbody hit_rb)
    {
        health -= amount;
        if(health <= 0)
        {
            Die(impact_direction, hit_rb);
        }
    }

    /// <summary>
    /// Function called when health value reaches or below threshold, 0
    /// </summary>
    /// <param name="impact_direction">direction of impact. must be passed via ray.direction</param>
    /// <param name="hit_rb">bone gameObject with rigidbody that was hit by RaycastHit passed via hit.rigidbody</param>
    void Die(Vector3 impact_direction, Rigidbody hit_rb)
    {
        ragdoll.ActivateRagdoll();
        impact_direction.y = 1f;
        ragdoll.impact_body_part = hit_rb;
        ragdoll.ApplyForce(impact_direction * impact_force, death_force_mode);
    }

    void CreateEntityRagdoll()
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in rigidbodies)
        {
            EntityHitbox entity_hitbox = rb.gameObject.AddComponent<EntityHitbox>();
            entity_hitbox.health = this;                                                //  health values for entity_hitbox equal to health value of Health.cs
        }
    }
}
