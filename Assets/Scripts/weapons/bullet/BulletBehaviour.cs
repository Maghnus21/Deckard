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
    public AIAgent agent;

    public GameObject bulllet_impact;
    public float damage = 20f;

    public bool debug_collision_cube = false;


    RaycastHit hit;
    Ray ray;
    float range = 8f;

    float maxtime = 2f;
    float time = 2;


    void Start()
    {
        time = maxtime;
        //  this is to prevent raycast from gun sight hitting bullet and sending world location data to change bullet spawn rotation
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");

        ray = new Ray(transform.position, transform.forward);

        if(Physics.Raycast(ray, out hit, 100f))
        {
            if (debug_collision_cube) { Instantiate(bulllet_impact, hit.point, Quaternion.identity); }



        }

        
    }

    private void Update()
    {
        /*
        ray = new Ray(transform.position, transform.forward);


        if (Physics.Raycast(ray, out hit, range) && hit.collider != null)
        {
            if (debug_collision_cube) { Instantiate(bulllet_impact, hit.point, Quaternion.identity); }

            if (hit.collider != null && hit.collider.GetComponent<EntityHitbox>())
            {
                hit.collider.GetComponent<EntityHitbox>().OnRaycastHit(damage, ray.direction, hit.rigidbody);

                if (hit.collider.GetComponentInParent<AIAgent>())
                {
                    agent = hit.collider.GetComponentInParent<AIAgent>();
                    agent.stateMachine.ChangeState(AIStateID.AttackPlayer);
                }
            }
            if (hit.collider != null && hit.collider.GetComponent<playerHitbox>())
            {
                hit.collider.GetComponent<playerHitbox>().onRaycastHitPlayer(damage);
            }

            Destroy(this.gameObject, 0.1f);
        }
        */




        time -= Time.deltaTime;

        if(time < 0f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + transform.forward);
    }
}
