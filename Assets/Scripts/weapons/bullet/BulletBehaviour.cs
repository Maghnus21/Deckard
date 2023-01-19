using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

/// <summary>
/// ISSUES:
/// force not applied to rigidbody when shot. link to tutorial for possible help: https://www.youtube.com/watch?v=zjuI5Jdzjxo
/// </summary>



public class BulletBehaviour : MonoBehaviour
{
    public GameObject bulllet_impact;
    public float damage = 60f;

    public bool debug_collision_cube = false;


    RaycastHit hit;
    Ray ray;
    float range = 100f;
    float hit_force = 100f;

    void Start()
    {
        Destroy(this.gameObject, 1f);


        //  this is to prevent raycast from gun sight hitting bullet and sending world location data to change bullet spawn rotation
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");


        if(Physics.Raycast(transform.position, transform.forward * range, out hit) && hit.collider.GetComponentInParent<enemyHealth>())
        {
            hit.collider.GetComponentInParent<enemyHealth>().health -= damage;

            if (hit.collider.GetComponentInParent<enemyHealth>().health <= 0)
            {
                hit.collider.GetComponentInParent<enemyHealth>().EnemyDeath();
                hit.rigidbody.AddExplosionForce(hit_force, hit.point, .1f);
            }

            if (gameObject.transform.position == hit.point)
            {
                Destroy(this.gameObject);
            }
        }

        



    }

    // Update is called once per frame
    void Update()
    {
        
    }


    
    private void OnCollisionEnter(Collision collision)
    {
        /*
        // checks if game object has enemyhealth script and health is greater than 0, then will damage enemy
        if(collision.gameObject.GetComponentInParent<enemyHealth>() == true && collision.gameObject.GetComponentInParent<enemyHealth>().health > 0f)
        {
            collision.gameObject.GetComponentInParent<enemyHealth>().health -= damage;

            if(collision.gameObject.GetComponentInParent<enemyHealth>().health <= 0f)
            {
                collision.gameObject.GetComponentInParent<enemyHealth>().EnemyDeath();
            }
        }

        else if(collision.gameObject.GetComponent<healthObject>() == true && collision.gameObject.GetComponent<healthObject>().health > 0f)
        {
            collision.gameObject.GetComponent<healthObject>().health -= damage;

            if (collision.gameObject.GetComponent<healthObject>().health <= 0f)
            {
                Destroy(collision.gameObject);
                
            }
        }

        if (debug_collision_cube)
        {
            Instantiate(bulllet_impact, transform.position, transform.rotation = Quaternion.Euler(Vector3.zero));
            

        }
        */

        Destroy(gameObject, 0.01f);
    }
    
}
