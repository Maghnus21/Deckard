using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
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

    RaycastHit hit;
    float range = 100f;

    // Start is called before the first frame update
    void Start()
    {
        //  this is to prevent raycast from gun sight hitting bullet and sending world location data to change bullet spawn rotation
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        if (Physics.Raycast(transform.position, transform.forward * range, out hit) && hit.collider.GetComponentInParent<enemyHealth>())
        {
           
            embed_rebar = Instantiate(dummy_rebar, hit.point, transform.rotation);
            embed_rebar.transform.SetParent(hit.transform, true);
            


            hit.collider.GetComponentInParent<enemyHealth>().health -= damage;

            if (hit.collider.GetComponentInParent<enemyHealth>().health <= 0)
            {
                hit.collider.GetComponentInParent<enemyHealth>().EnemyDeath();
            }

            if (gameObject.transform.position == hit.point)
            {
                Destroy(this.gameObject);
            }
        }
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.GetComponent<Collider>() == true)
        {
            Debug.Log("HIT COLLIDER");

            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            this.gameObject.GetComponent<Collider>().enabled = false;

            bar.GetComponent<CapsuleCollider>().enabled = true;
        }

        if (collision.gameObject.GetComponent<Collider>() == true && collision.gameObject.GetComponentInParent<enemyHealth>())
        {
            Debug.Log("HIT COLLIDER");

            if (!is_parented)
            {
                gameObject.transform.SetParent(collision.transform, true);
                is_parented = true;
            }

            this.gameObject.GetComponent<Collider>().enabled = false;

            if(collision.gameObject.GetComponentInParent<enemyHealth>().health > 0)
            {
                //collision.gameObject.GetComponentInParent<enemyHealth>().health -= damage;
            }

            
            if(collision.gameObject.GetComponentInParent<enemyHealth>().health <= 0)
            {
                collision.gameObject.GetComponentInParent<enemyHealth>().EnemyDeath();
            }
            

        }
    } */


}
