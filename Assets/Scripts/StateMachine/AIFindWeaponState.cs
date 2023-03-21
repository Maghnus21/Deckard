using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using UnityEngine;

public class AIFindWeaponState : AIState
{
    public void Enter(AIAgent agent)
    {
        agent.weaponIK.enabled = false;
        agent.head_tracking.enabled = false;

        WeaponPickup pickup = FindClosestWeapon(agent);
        agent.navMeshAgent.destination = pickup.transform.position;
        agent.navMeshAgent.speed = 6;
    }

    public void Exit(AIAgent agent)
    {
        
    }

    public AIStateID getID()
    {
        return AIStateID.FindWeapon;
    }

    public void Update(AIAgent agent)
    {
        if (agent.weapon.HasWeapon())
        {
            agent.stateMachine.ChangeState(AIStateID.WeaponActive);
        }
    }

    private WeaponPickup FindClosestWeapon(AIAgent agent)
    {
        WeaponPickup[] weapons = Object.FindObjectsOfType<WeaponPickup>();
        WeaponPickup closest_weapon = null;
        float closest_distance = float.MaxValue;

        foreach(var weapon in weapons)
        {
            float distance_to_weapon = Vector3.Distance(agent.transform.position, weapon.transform.position);
            if(distance_to_weapon < closest_distance)
            {
                closest_distance = distance_to_weapon;
                closest_weapon = weapon;
            }
        }
        return closest_weapon;
    }
}
