using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class objectDestruction : MonoBehaviour
{
    public Health health;
    public GameObject destructable_object;

    private void Awake()
    {
        health = GetComponent<Health>();
    }


    // Update is called once per frame
    void Update()
    {
        if(health.health <= 0)
        {
            if(destructable_object != null)
                Instantiate(destructable_object,transform.position, transform.rotation);

            Destroy(this.gameObject);
        }
    }

    
}
