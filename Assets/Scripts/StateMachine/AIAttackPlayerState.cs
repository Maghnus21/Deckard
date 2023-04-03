using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIAttackPlayerState : AIState
{
    float fire_rate = 1;
    float next_round = 0;


    public void Enter(AIAgent agent)
    {
        agent.ai_weapon.ActivateWeapon();
        agent.ai_weapon.SetTarget(agent.player_transform);
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
        /*
        if(distance > 15f)
        {
            agent.is_aggressive = false;

            return;
        }
        */

        agent.is_aggressive = true;

        if(agent.player_gameobject.GetComponent<playerHealth>().health > 0)
        {
            if(Time.time > next_round)
            {
                agent.navMeshAgent.destination = agent.player_transform.position;

                if(distance < 10f)
                {
                    agent.ai_weapon.FireWeapon();
                    
                }
                

                next_round = Time.time + fire_rate;
            }
        }
    }
}
