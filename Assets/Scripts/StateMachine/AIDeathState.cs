using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDeathState : AIState
{
    

    public void Enter(AIAgent agent)
    {
        //agent.branch_dialogue.enabled = false;


        
        /*
        agent.ragdoll.ActivateRagdoll();
        agent.impact_direction.y = 1f;
        agent.ragdoll.impact_body_part = agent.hit_rb;
        agent.ragdoll.ApplyForce(agent.impact_direction * agent.config.impact_force, agent.health.death_force_mode);
        */

        agent.weapon.UnparentWeapon();

        agent.DisableScripts();
        /*
        agent.weapon.enabled = false;
        agent.weaponIK.enabled = false;
        agent.head_tracking.enabled = false;
        */
    }

    public void Exit(AIAgent agent)
    {
        
    }

    public AIStateID getID()
    {
        return AIStateID.Death;
    }

    public void Update(AIAgent agent)
    {
        
    }
}
