using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosiveHealth : MonoBehaviour
{
    Health health;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health.health <= 0)
        {
            GetComponentInChildren<explode>().has_exploded = true;
            GetComponentInChildren<explode>().Explode();
        }
    }
}
