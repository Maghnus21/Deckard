using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

/// <summary>
/// ISSUES:
/// (SEMI_FIXED) force not applied to rigidbody when shot. link to tutorial for possible help: https://www.youtube.com/watch?v=zjuI5Jdzjxo
/// force applied to rigidbody in objects but not on enemy ragdolls, go investigate
/// </summary>



public class BulletBehaviour : MonoBehaviour
{
    public GameObject bulllet_impact;
    public float damage = 60f;

    public bool debug_collision_cube = false;


    RaycastHit hit;
    Ray ray;
    float range = 100f;
    float hit_force = 5f;

    Collider[] colliders;

    void Start()
    {
        Destroy(this.gameObject, 3f);



        //  this is to prevent raycast from gun sight hitting bullet and sending world location data to change bullet spawn rotation
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");


        if(Physics.Raycast(transform.position, transform.forward * range, out hit))
        {
            if(hit.collider != null && hit.collider.CompareTag("Suspect"))
            {
                hit.collider.GetComponentInParent<enemyHealth>().health -= damage;
                Instantiate(bulllet_impact, hit.point, Quaternion.identity);


                if (hit.collider.GetComponentInParent<enemyHealth>().health <= 0)
                {
                    colliders = Physics.OverlapSphere(hit.point, 5f);

                    Instantiate(bulllet_impact, hit.point, Quaternion.identity);

                    hit.collider.GetComponentInParent<EnemyController>().enemyDie();

                }

            }

            //  applies force to object including enemies. commented out until better combat system devised
            /*
            if(hit.collider != null && !hit.collider.CompareTag("Suspect"))
            {
                Debug.Log("HIT OBJECT" + hit.collider.name);

                if(hit.rigidbody != null && !hit.rigidbody.isKinematic)
                {
                    hit.rigidbody.AddForce(transform.forward * hit_force, ForceMode.Impulse);
                }
            }
            */
            else
            {

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

        //Destroy(gameObject, 0.01f);
    }
    
}
