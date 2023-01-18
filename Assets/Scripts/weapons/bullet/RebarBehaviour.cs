using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebarBehaviour : MonoBehaviour
{
    public LayerMask obj_layer;
    public GameObject bar;
    public float damage = 45f;

    //  ensures object only parents once with hit object and not upon collision with passing objects
    bool is_parented = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.GetComponent<Collider>() == true)
        {
            Debug.Log("HIT COLLIDER");

            if (!is_parented)
            {
                gameObject.transform.parent = collision.transform;
                is_parented = true;
            }

            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            this.gameObject.GetComponent<Collider>().enabled = false;

            bar.GetComponent<CapsuleCollider>().enabled = true;
        }

        if (collision.gameObject.GetComponent<Collider>() == true && collision.gameObject.GetComponentInParent<enemyHealth>())
        {
            Debug.Log("HIT COLLIDER");

            if (!is_parented)
            {
                gameObject.transform.parent = collision.transform;
                is_parented = true;
            }

            this.gameObject.GetComponent<Collider>().enabled = false;

            if(collision.gameObject.GetComponentInParent<enemyHealth>().health > 0)
            {
                collision.gameObject.GetComponentInParent<enemyHealth>().health -= damage;
            }

            if(collision.gameObject.GetComponentInParent<enemyHealth>().health <= 0)
            {
                collision.gameObject.GetComponentInParent<enemyHealth>().EnemyDeath();
            }

        }
    }

}
