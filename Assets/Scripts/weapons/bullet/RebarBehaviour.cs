using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebarBehaviour : MonoBehaviour
{
    public LayerMask obj_layer;
    public GameObject bar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.GetComponent<Collider>() == true)
        {
            Debug.Log("HIT COLLIDER");

            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            this.gameObject.GetComponent<Collider>().enabled = false;

            bar.GetComponent<CapsuleCollider>().enabled = true;
        }
    }

}
