using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public Enemy enemy_type;
    

    Rigidbody[] ragdollRigidbodies;


    public float health;
    bool is_enemy_alive;

    void Awake()
    {
        //EnemyAlive();

        
        health = enemy_type.health;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*

    //  function to be called to initiate enemy death. sets rigidbodies to disable kinematics and enemy ragdolls
    public void EnemyDeath()
    {
        is_enemy_alive = false;

        foreach(var rb in ragdollRigidbodies)
        {
            rb.isKinematic = false;
        }

        this.gameObject.GetComponent<EnemyNavigation>().enabled = false;
    }

    //  new code
    public void EnemyDeathImpact(float impact_force, Vector3 pos)
    {
        EnemyDeath();

        foreach(Rigidbody rb in ragdollRigidbodies)
        {
            rb.AddExplosionForce(impact_force, pos, .1f, .1f, ForceMode.Impulse);
        }
    }

    //  function to fill out rigidbodies array. to be called on awake
    void EnemyAlive()
    {
        is_enemy_alive = true;

        ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach (var rb in ragdollRigidbodies)
        {
            rb.isKinematic = true;
        }
    }

    */
    
}
