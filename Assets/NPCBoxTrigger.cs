using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBoxTrigger : MonoBehaviour
{
    public bool can_fire = false;
    public AIWeapon weapon;
    public AIAgent agent;

    private void Start()
    {
        weapon = GetComponentInParent<AIWeapon>();
        agent = GetComponentInParent<AIAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && agent.is_aggressive)
            weapon.SetFiring(true);
            //can_fire = true;   
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && agent.is_aggressive)
            weapon.SetFiring(false);
            //can_fire = false;
    }
}
