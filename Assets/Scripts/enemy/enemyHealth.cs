using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public Enemy enemy_type;
    Collider collider;

    Rigidbody[] ragdollRigidbodies;


    public float health;
    bool is_enemy_alive;

    void Awake()
    {
        EnemyAlive();

        collider = GetComponent<Collider>();
        health = enemy_type.health;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //  is_enemy_alive prevents EnemyDeath running every frame
        if (health == 0 && is_enemy_alive)
        {
            collider.enabled = false;
            EnemyDeath();
        }
    }

    public void EnemyDeath()
    {
        is_enemy_alive = false;

        foreach(var rb in ragdollRigidbodies)
        {
            rb.isKinematic = false;
        }

        
        Collider col = this.gameObject.GetComponent<Collider>();
        col.enabled = false;

        this.gameObject.GetComponent<EnemyNavigation>().enabled = false;
    }

    void EnemyAlive()
    {
        is_enemy_alive = true;

        ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach (var rb in ragdollRigidbodies)
        {
            rb.isKinematic = true;
        }
    }

    
}
