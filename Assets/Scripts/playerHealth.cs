using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public float health = 100f;
    public GameObject player_ragdoll;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            playerReceiveDamage(10);
        }
    }



    public void playerReceiveDamage(float damage)
    {
        health -= damage;
        

        if(health <= 0)
        {
            playerDeath();
            GetComponent<PlayerHealthUI>().reduceHP(100);
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
}
