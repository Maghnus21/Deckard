using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenade : MonoBehaviour
{
    Collider[] colliders = null;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 4f, ForceMode.Impulse);

        Invoke("grenadeExplode", 5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void grenadeExplode()
    {
        colliders = Physics.OverlapSphere(transform.position, 5f);
        

        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.GetComponent<EntityHitbox>())
            {
                print("HIT HITBOX" + collider.gameObject.name);
                collider.gameObject.GetComponentInParent<EntityHitbox>().ExplosiveHit(100f, transform.position);

            }

            
            Rigidbody rb = collider.GetComponent<Rigidbody>();

            if(rb != null)
            {
                rb.AddExplosionForce(80f, transform.position, 10f, 5f);
            }
            
        }

        Destroy(this.gameObject);
    }
}
