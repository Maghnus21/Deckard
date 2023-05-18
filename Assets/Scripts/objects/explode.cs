using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class explode : MonoBehaviour
{
    Collider[] coll_check;
    List<Collider> list = new List<Collider>();


    //  floats for explosion physics. following values are explosion defaults
    float explosion_damage = 30f;
    public float explosion_force = 10f;
    public float explosion_radius = 3f;
    public float explosion_upforce = 1f;

    public bool manual_explode = false;
    public bool has_exploded = false;

    public GameObject explosion_image_plane;
    public ParticleSystem explosion_particles;
    public GameObject player;

    private void Start()
    {
        player = GameObject.Find("player");

        Destroy(gameObject, 2f);
    }


    private void Update()
    {
        //  DEBUGGING
        if (manual_explode && !has_exploded)
        {
            Explode();
        }        
    }



    public void Explode()
    {
        has_exploded = true;

        explosion_particles.transform.position = transform.position;
        explosion_particles.Emit(1);

        //checkExplosionLOS();

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosion_radius);     // to be kept until los fix

        foreach (Collider collider in colliders)
            list.Add(collider);

        list.RemoveAll(collider => !collider);

        /*
        list.ForEach(collider =>
        {
            
                
        });*/

        foreach (Collider collider in list)
        {
            if (collider.gameObject.GetComponent<EntityHitbox>() && collider.gameObject.GetComponent<EntityHitbox>().health != null && collider.gameObject.activeInHierarchy)
            {
                print("hit " + collider.name);
                float entity_dis = Vector3.Distance(transform.position, collider.transform.position);
                collider.gameObject.GetComponent<EntityHitbox>().ExplosiveHit(calculateDistanceDamage(entity_dis), transform.position, explosion_force, explosion_radius, explosion_upforce);
            }
            else if(collider.gameObject.GetComponent<playerHitbox>() && collider.gameObject.GetComponent<playerHealth>().health >=0f && collider.gameObject.activeInHierarchy)
            {
                print("hit " + collider.name);
                float entity_dis = Vector3.Distance(transform.position, collider.transform.position);
                collider.gameObject.GetComponent<playerHitbox>().onRaycastHitPlayer(calculateDistanceDamage(entity_dis));
            }
            

                
            else { }
        }
            



        /*
        foreach (Collider collider in colliders)
        {
            //print("HIT COLLIDER " + collider.gameObject.name);

            
            //  check makes sure hit NPC doesn't instantiate multiple gib_body prefabs
            if (collider.gameObject.GetComponent<EntityHitbox>() && collider.gameObject.GetComponentInParent<Health>().health > 0f)
            {
                print("HIT HITBOX" + collider.gameObject.name);

                float entity_dis = Vector3.Distance(transform.position, collider.transform.position);


                collider.gameObject.GetComponent<EntityHitbox>().ExplosiveHit(calculateDistanceDamage(entity_dis), transform.position, explosion_force, explosion_radius, explosion_upforce);

            }
            if (collider.gameObject.GetComponent<playerHitbox>())
            {
                float entity_dis = Vector3.Distance(transform.position, collider.transform.position);
                collider.gameObject.GetComponent<playerHitbox>().explodeHitPlayer(calculateDistanceDamage(entity_dis), explosion_force, explosion_radius, explosion_upforce, transform.position);
                print("HIT PLAYER");
            }
            else
            {
                Rigidbody rb = collider.gameObject.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.AddExplosionForce(explosion_force, transform.position, explosion_radius, explosion_upforce, ForceMode.Impulse);
                }
            }
            


        }
        */
    }

    void checkExplosionLOS()
    {
        coll_check = Physics.OverlapSphere(transform.position, explosion_radius);

        Ray ray;
        RaycastHit hit;

        foreach(Collider collider in coll_check)
        {
            ray = new Ray(transform.position, collider.transform.position - transform.position);

            if (Physics.Raycast(ray, out hit, explosion_radius))
            {
                if (hit.collider.gameObject.GetComponent<Rigidbody>())
                {
                    list.Add(hit.collider);
                }
            }
        }

        print("FINISHED EXPLOSION LOS: " + gameObject.name);
    }

    float calculateDistanceDamage(float distance)
    {
        float damage = explosion_damage / distance;

        /*
        if(distance > explosion_radius / 2)
        {
            damage = (explosion_damage / (1 / distance));
        }
        else
        {
            damage = explosion_damage;
        }
        */

        return damage;
    }

    
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(Color.red.r, Color.red.g, Color.red.b, 0.3f);
        Gizmos.DrawSphere(transform.position, explosion_radius);        
    }
    
}
