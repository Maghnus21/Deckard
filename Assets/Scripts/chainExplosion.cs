using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chainExplosion : MonoBehaviour
{
    Collider[] colliders;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        colliders = Physics.OverlapSphere(transform.position, 3f);

        

    }
}
