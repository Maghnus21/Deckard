using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDeathState : AIState
{

    float time = 0;
    public void Enter(AIAgent agent)
    {
        Debug.Log(agent.name + " entered state: AIDeathState");

        agent.npc_audio_source.Stop();

        agent.ragdoll.ActivateRagdoll();
        agent.impact_direction.y = 1f;
        agent.ragdoll.impact_body_part = agent.hit_rb;
        //agent.ragdoll.ApplyForce(agent.impact_direction * agent.config.impact_force, agent.health.death_force_mode);
        

        agent.ai_weapon.DropWeapon();

        agent.ai_weapon.enabled = false;

        //  ai_weapon_ik must be disabled first as errors prevent rest being disabled
        //  don't fucking touch please
        agent.ai_weapon_ik.enabled = false;

        
        agent.mesh_sockets.enabled = false;
        agent.enemy_los.enabled = false;
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
