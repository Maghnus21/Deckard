using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class explode : MonoBehaviour
{
    Collider[] coll_check;
    List<Collider> list = new List<Collider>();
    

    //  floats for explosion physics. following values are explosion defaults
    public float explosion_force = 10f;
    public float explosion_radius = 3f;
    public float explosion_upforce = 1f;

    public bool manual_explode = false;
    public bool has_exploded = false;

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

        checkExplosionLOS();

        foreach (Collider collider in list)
        {
            //  check makes sure hit NPC doesn't instantiate multiple gib_body prefabs
            if (collider.gameObject.GetComponent<EntityHitbox>() && collider.gameObject.GetComponentInParent<Health>().health > 0)
            {
                print("HIT HITBOX" + collider.gameObject.name);

                float damage_over_dis = Vector3.Distance(transform.position, collider.transform.position);
                collider.gameObject.GetComponent<EntityHitbox>().ExplosiveHit(30f / damage_over_dis, transform.position, explosion_force, explosion_radius, explosion_upforce);
                
            }
            
            
            Rigidbody rb = collider.GetComponent<Rigidbody>();

            if(rb != null)
            {
                rb.AddExplosionForce(explosion_force, transform.position, explosion_radius, explosion_upforce, ForceMode.Impulse);
            }
        }

        
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

    
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(Color.red.r, Color.red.g, Color.red.b, 0.3f);
        Gizmos.DrawSphere(transform.position, explosion_radius);        
    }
    
}
