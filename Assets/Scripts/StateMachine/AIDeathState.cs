using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDeathState : AIState
{

    float time = 0;
    public void Enter(AIAgent agent)
    {
        agent.ragdoll.ActivateRagdoll();
        agent.impact_direction.y = 1f;
        agent.ragdoll.impact_body_part = agent.hit_rb;
        agent.ragdoll.ApplyForce(agent.impact_direction * agent.config.impact_force, agent.health.death_force_mode);
        

        agent.ai_weapon.UnparentWeapon();

        //  disable scripts here
        if (agent.ai_weapon.enabled)
            agent.ai_weapon.enabled = false;
        agent.enabled = false;
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
