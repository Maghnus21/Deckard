using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftPlayerParent : MonoBehaviour
{
    public GameObject lift;
    GameObject player;

    //  When player enters lift, player gameobject parented to lift gameobject. this ensures that the player is moving with the lift and reducing issues with physics
    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.GetComponent<rigidbodyMovement>() != null)
        {
            player = other.gameObject;

            player.transform.SetParent(lift.transform);
        }
    }

    //  unparents player and clears player gameobject
    private void OnTriggerExit(Collider other)
    {
        player.transform.SetParent(null);
        player = null;
    }
}
