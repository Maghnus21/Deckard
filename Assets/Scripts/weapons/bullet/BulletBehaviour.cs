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
    public float damage = 20f;

    public bool debug_collision_cube = false;


    RaycastHit hit;
    Ray ray;
    float range = 1f;

    void Start()
    {
        



        //  this is to prevent raycast from gun sight hitting bullet and sending world location data to change bullet spawn rotation
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");

        ray = new Ray(transform.position, transform.forward * range);


        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider != null && hit.collider.GetComponent<EntityHitbox>())
            {
                hit.collider.GetComponent<EntityHitbox>().OnRaycastHit(damage, ray.direction, hit.rigidbody);

                Destroy(this.gameObject);
            }
            else
            {
                
            }



            if (debug_collision_cube) { Instantiate(bulllet_impact, hit.point, Quaternion.identity); }
            Destroy(gameObject, 0.1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    
}
