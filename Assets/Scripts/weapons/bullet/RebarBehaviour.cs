using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class RebarBehaviour : MonoBehaviour
{
    public LayerMask obj_layer;
    public GameObject bar;
    public float damage = 45f;

    //  ensures object only parents once with hit object and not upon collision with passing objects
    bool is_parented = false;

    public GameObject dummy_rebar;
    GameObject embed_rebar;

    Ray ray;
    RaycastHit hit;
    float range = 2f;

    // Start is called before the first frame update
    void Start()
    {
        //  this is to prevent raycast from gun sight hitting bullet and sending world location data to change bullet spawn rotation
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");

        ray = new Ray(transform.position, transform.forward * range);

        if (Physics.Raycast(ray, out hit))
        {
            //  conditional statement for when rebar hits wall, crate, etc
            if (!hit.collider.CompareTag("Suspect"))
            {
                embed_rebar = Instantiate(dummy_rebar, hit.point, transform.rotation);
                embed_rebar.transform.SetParent(hit.transform, true);
                //embed_rebar.GetComponentInChildren<Collider>().enabled = true;

                Destroy(this.gameObject, .01f);
            }


            if(hit.collider != null && hit.collider.gameObject.GetComponent<EntityHitbox>())
            {
                embed_rebar = Instantiate(dummy_rebar, hit.point, transform.rotation);
                embed_rebar.transform.SetParent(hit.transform, true);

                hit.collider.GetComponent<EntityHitbox>().OnRaycastHit(damage, ray.direction, hit.rigidbody);

                hit.collider.GetComponentInParent<Health>().impact_force = 70f;
                hit.collider.GetComponentInParent<Health>().death_force_mode = false;
            }


            /*
            //  conditional statement for when rebar strikes enemy containing a skeleton and ragdoll
            else
            {
                embed_rebar = Instantiate(dummy_rebar, hit.point, transform.rotation);
                embed_rebar.transform.SetParent(hit.transform, true);

                hit.collider.GetComponentInParent<Health>().impact_force = 70f;
                hit.collider.GetComponentInParent<Health>().death_force_mode = false;
                //hit.collider.GetComponent<EntityHitbox>().OnRaycastHit(damage, ray.direction, hit.rigidbody);
                

                Destroy(this.gameObject, .01f);
            }
            */
            
        }
    }
}
