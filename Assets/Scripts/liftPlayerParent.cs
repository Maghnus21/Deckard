using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftPlayerParent : MonoBehaviour
{
    public GameObject lift;
    GameObject player;

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.GetComponent<rigidbodyMovement>() != null)
        {
            player = other.gameObject;

            player.transform.SetParent(lift.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        player.transform.SetParent(null);
        player = null;
    }
}
