using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class explode : MonoBehaviour
{
    //Collider[] colliders = null;

    Collider[] coll_check;

    List<Collider> list = new List<Collider>();

    public bool has_exploded = false;

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
                collider.gameObject.GetComponentInParent<EntityHitbox>().ExplosiveHit(10f * damage_over_dis, transform.position);

            }
            
            Rigidbody rb = collider.GetComponent<Rigidbody>();

            if(rb != null)
            {
                rb.AddExplosionForce(10f, transform.position, 3f, 5f, ForceMode.VelocityChange);
            }
        }

        

        Destroy(this.gameObject, .05f);
    }

    void checkExplosionLOS()
    {
        coll_check = Physics.OverlapSphere(transform.position, 6f);

        Ray ray = new Ray(transform.position, coll_check[0].transform.position - transform.position);
        RaycastHit hit;

        foreach(Collider collider in coll_check)
        {
            ray = new Ray(transform.position, collider.transform.position - transform.position);

            if (Physics.Raycast(ray, out hit, 6f))
            {
                if (hit.collider.GetComponent<Rigidbody>())
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
        Gizmos.DrawSphere(transform.position, 3f);
    }


}
