using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttackPlayerState : AIState
{
    public void Enter(AIAgent agent)
    {
        Debug.Log(agent.name + " entered state: AIAttackPlayerState");

        agent.ai_weapon.ActivateWeapon();
        agent.ai_weapon_ik.SetTargetTransform(agent.player_transform);

        agent.navMeshAgent.stoppingDistance = 5f;

        agent.ai_weapon.SetFiring(true);
    }

    public void Exit(AIAgent agent)
    {
        
    }

    public AIStateID getID()
    {
        return AIStateID.AttackPlayer;
    }

    public void Update(AIAgent agent)
    {
        agent.navMeshAgent.destination = agent.player_transform.position;
    }

    
}
