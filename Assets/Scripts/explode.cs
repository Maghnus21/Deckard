using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour
{
    Collider[] colliders = null;

    public bool has_exploded = false;

    void Explode()
    {
        colliders = Physics.OverlapSphere(transform.position, 5f);

        foreach(Collider collider1 in colliders)
        {
            
        }
        

        foreach (Collider collider in colliders)
        {
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

        Destroy(this.gameObject);

        
    }

    private void OnDrawGizmos()
    {

        Gizmos.color = new Color(Color.red.r, Color.red.g, Color.red.b, 0.3f);
        Gizmos.DrawSphere(transform.position, 3f);
    }


}
