using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gib_explosion : MonoBehaviour
{
    public float radius = 2f;
    public float force = 10f;

    public GameObject explosion_point;
    Collider[] colliders;

    // Start is called before the first frame update
    void Start()
    {
        colliders = Physics.OverlapSphere(explosion_point.transform.position, radius);

        foreach(Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();

            if(rb != null)
            {
                rb.AddExplosionForce(force, explosion_point.transform.position, radius, 3f);
            }
        }
    }
}
