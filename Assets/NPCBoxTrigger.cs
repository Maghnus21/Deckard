using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBoxTrigger : MonoBehaviour
{
    public bool in_trigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            in_trigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            in_trigger = false;
    }
}
