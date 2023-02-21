using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladderClimb : MonoBehaviour
{
    float climb_speed = 5f;

    private Coroutine climb_coroutine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<rigidbodyMovement>(out rigidbodyMovement rbm ))
        {
            if (!rbm.is_climbing)
            {
                rbm.is_climbing = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<rigidbodyMovement>(out rigidbodyMovement rbm))
        {
            rbm.is_climbing = false;
        }
    }
}
