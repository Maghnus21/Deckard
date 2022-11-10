using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public float health = 100;

    Rigidbody[] ragdollRigidbodies;

    void Awake()
    {
        ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach(var rb in ragdollRigidbodies)
        {
            rb.isKinematic = true;
        }

        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            death();
        }
    }

    void death()
    {
        foreach(var rb in ragdollRigidbodies)
        {
            rb.isKinematic = false;
        }

        
        Collider col = this.gameObject.GetComponent<Collider>();
        col.enabled = false;

        this.gameObject.GetComponent<EnemyNavigation>().enabled = false;
    }
}
