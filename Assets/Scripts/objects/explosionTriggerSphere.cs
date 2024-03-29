using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionTriggerSphere : MonoBehaviour
{
    public Collider parent_explosive;
    GameObject explosive_obj;

    RaycastHit hit;
    Ray ray;

    


    // Start is called before the first frame update
    void Start()
    {
        Random.seed = (int)System.DateTime.Now.Ticks;
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
            explosive_obj = other.gameObject;
        }

        if(Physics.Raycast(ray, out hit, 3f))
        {

            if (hit.collider.GetComponent<explode>())
            {
                if (other.gameObject.GetComponent<explode>() && !other.gameObject.GetComponent<explode>().has_exploded)
                {

                    
                    if (parent_explosive.GetComponent<explode>().has_exploded)
                    {
                        explosive_obj.GetComponent<explode>().has_exploded = true;
                        explosive_obj.GetComponent<explode>().Invoke("Explode", 5);

                        Destroy(this.gameObject);
                    }


                }

            }



        }



        

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(ray);
    }
}
