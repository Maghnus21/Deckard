using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIChasePlayerState : AIState
{
    
    float timer;

    public AIStateID getID()
    {
        return AIStateID.ChasePlayer;
    }

    public void Enter(AIAgent agent)
    {
        
    }

    public void Exit(AIAgent agent)
    {

    }

    public void Update(AIAgent agent)
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            if (agent.navMeshAgent.enabled)
            {
                float sqdistance = (agent.player_transform.position - agent.navMeshAgent.destination).magnitude;
                if (sqdistance > agent.config.maxDistance * agent.config.maxDistance)
                {
                    agent.navMeshAgent.destination = agent.player_transform.position;
                }
                timer = agent.config.maxTime;
            }
            
        }


        
    }
}
