using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public GameObject bulllet_impact;
    public float damage = 60f;

    public bool debug_collision_cube = false;

    void Start()
    {
        Destroy(this.gameObject, 1f);

        //  this is to prevent raycast from gun sight hitting bullet and sending world location data to change bullet spawn rotation
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // checks if game object has enemyhealth script and health is greater than 0, then will damage enemy
        if(collision.gameObject.GetComponent<enemyHealth>() == true && collision.gameObject.GetComponent<enemyHealth>().health > 0f)
        {
            collision.gameObject.GetComponent<enemyHealth>().health -= damage;

            if(collision.gameObject.GetComponent<enemyHealth>().health <= 0f)
            {
                collision.gameObject.GetComponent<enemyHealth>().EnemyDeath();
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

        Destroy(gameObject, 0.01f);
    }
}
