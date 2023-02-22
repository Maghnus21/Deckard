using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionTriggerSphere : MonoBehaviour
{
    public GameObject parent_grenade;
    GameObject test;

    RaycastHit hit;
    Ray ray;


    // Start is called before the first frame update
    void Start()
    {
        Gizmos.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        ray = new Ray(transform.position, other.transform.position - transform.position);
        


        if (other.gameObject.GetComponent<explode>())
        {
            test = other.gameObject;
        }

        if(Physics.Raycast(ray, out hit, 6f))
        {

            if (hit.collider.GetComponent<explode>())
            {
                if (other.gameObject.GetComponent<explode>() && !other.gameObject.GetComponent<explode>().has_exploded)
                {

                    //print("GRENADE " + other.name);

                    if (parent_grenade.GetComponent<explode>().has_exploded)
                    {
                        test.GetComponent<explode>().has_exploded = true;
                        test.GetComponent<explode>().Invoke("Explode", .3f);

                    }


                }

            }



        }



        

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(ray);
    }
}
