using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWeaponActive : AIState
{
    public void Enter(AIAgent agent)
    {
        if(agent.weapon.equipted_gun != null)
        {
            agent.weapon.ActivateWeapon();
            return;
        }

        

        GameObject held_gun = agent.CloneNPCGun();
        if (agent.mesh_socket.attach_point != null)
        {
            held_gun.transform.SetParent(agent.mesh_socket.attach_point, false);
        }

        agent.weapon.ActivateWeapon();
    }

    public void Exit(AIAgent agent)
    {

    }

    public AIStateID getID()
    {
        return AIStateID.WeaponActive;
    }

    public void Update(AIAgent agent)
    {

    }
}
