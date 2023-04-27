using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    float max_health = 100f;
    public float health = 100f;
    public GameObject player_ragdoll;
    Rigidbody[] rb;

    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.H))
        {
            playerReceiveDamage(10);
        }
        */
    }



    public void playerReceiveDamage(float damage)
    {
        health -= damage;
        

        if(health <= 0)
        {
            GetComponent<PlayerHealthUI>().reduceHP(100);
            playerDeath();
            
        }
        else
        {
            GetComponent<PlayerHealthUI>().reduceHP(damage);
        }
    }

    public void playerReceiveDamage(float damage, float exp_force, float exp_radius, float exp_up, Vector3 exp_pos)
    {
        health -= damage;


        if (health <= 0)
        {
            GetComponent<PlayerHealthUI>().reduceHP(100);
            playerDeath(exp_force, exp_radius, exp_up, exp_pos);

        }
        else
        {
            GetComponent<PlayerHealthUI>().reduceHP(damage);
        }
    }

    void playerDeath()
    {
        GameObject corpse = Instantiate(player_ragdoll, transform.position, transform.rotation);
        this.gameObject.SetActive(false);
    }

    void playerDeath(float exp_force, float exp_radius, float exp_up, Vector3 exp_pos)
    {
        GameObject corpse = Instantiate(player_ragdoll, transform.position, transform.rotation);
        rb = corpse.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rb2 in rb)
        {
            rb2.AddExplosionForce(exp_force, exp_pos, exp_radius, exp_up, ForceMode.Impulse);
        }

        this.gameObject.SetActive(false);
    }

    public void PlayerHeal(float heal)
    {
        if(health >= max_health-heal)
        { 
            
            GetComponent<PlayerHealthUI>().reduceHP(-(max_health - health));
            health = max_health;
        }
        else
        {
            health += heal;
            GetComponent<PlayerHealthUI>().reduceHP(-heal);
        }
            

        
    }
}
