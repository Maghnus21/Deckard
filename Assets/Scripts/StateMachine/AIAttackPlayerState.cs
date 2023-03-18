using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttackPlayerState : AIState
{
    public void Enter(AIAgent agent)
    {
        agent.weapon.ActivateWeapon();
        agent.weapon.SetTarget(agent.player_transform);
        agent.navMeshAgent.stoppingDistance = 8f;
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
        float distance = Vector3.Distance(agent.transform.position, agent.player_transform.position);
        if(distance > 15f)
        {
            return;
        }

        agent.navMeshAgent.destination = agent.player_transform.position;
    }
}
