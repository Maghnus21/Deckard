using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakObject : MonoBehaviour
{
    public float health = 150;
    // Start is called before the first frame update
    void Start()
    {
        if(health < 200)
        {
            Destroy(gameObject);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        
    }
}
