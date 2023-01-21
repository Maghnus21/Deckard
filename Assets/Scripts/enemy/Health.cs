using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Enemy enemy_type;
    Ragdoll ragdoll;

    float impact_force = 10f;

    public float health;

    void Awake()
    {
        health = enemy_type.health;

        ragdoll = GetComponent<Ragdoll>();

        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody rb in rigidbodies)
        {
             EntityHitbox entity_hitbox = rb.gameObject.AddComponent<EntityHitbox>();
            entity_hitbox.health = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceiveDamage(float amount, Vector3 impact_direction)
    {
        health -= amount;
        if(health <= 0)
        {
            Die(impact_direction);
        }
    }
  
    void Die(Vector3 impact_direction)
    {
        ragdoll.ActivateRagdoll();
        impact_direction.y = 1f;
        ragdoll.ApplyForce(impact_direction * impact_force);
    }
}
