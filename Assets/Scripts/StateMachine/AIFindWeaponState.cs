using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using UnityEngine;

public class AIFindWeaponState : AIState
{
    public void Enter(AIAgent agent)
    {
        Debug.Log(agent.name + " entered state: AIFindWeaponState");
        if (agent.ai_weapon.HasWeapon())
        {
            agent.ai_weapon.ActivateWeapon();
            //agent.ai_weapon.EquiptWeapon();
            agent.ai_weapon_ik.enabled = true;
            agent.stateMachine.ChangeState(AIStateID.Idle);
        }


        else 
        { 
            WeaponPickup pickup = FindClosestWeapon(agent);
            agent.navMeshAgent.destination = pickup.transform.position;
            agent.navMeshAgent.speed = 6;
        }

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
        if (agent.ai_weapon.HasWeapon())
        {
            agent.ai_weapon.ActivateWeapon();
        }
    }

    private WeaponPickup FindClosestWeapon(AIAgent agent)
    {
        WeaponPickup[] weapons = Item.FindObjectsOfType<WeaponPickup>();
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
