using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDeathState : AIState
{
    public Vector3 impact_direction;
    public Rigidbody hit_rb;
    public AIWeapon weapon;
    public AIWeaponIK weapon_IK;

    public void Enter(AIAgent agent)
    {
        //agent.branch_dialogue.enabled = false;

        agent.ragdoll.ActivateRagdoll();
        impact_direction.y = 1f;
        agent.ragdoll.impact_body_part = hit_rb;
        agent.ragdoll.ApplyForce(impact_direction * agent.config.impact_force, agent.health.death_force_mode);

        weapon = agent.GetComponent<AIWeapon>();
        weapon.UnparentWeapon();
        weapon_IK = agent.weaponIK;
        weapon_IK.enabled = false;
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
