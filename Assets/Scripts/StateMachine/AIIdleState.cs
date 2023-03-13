using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using UnityEngine;

public class AIIdleState : AIState
{
    public void Enter(AIAgent agent)
    {
    }

    public void Exit(AIAgent agent)
    {
    }

    public AIStateID getID()
    {
        return AIStateID.Idle;
    }

    public void Update(AIAgent agent)
    {
        Vector3 player_direction = agent.player_transform.transform.position - agent.transform.position;


        if (player_direction.magnitude > agent.config.max_los_distance)
        {
            return;
        }

        Vector3 agent_direction = agent.transform.forward;

        player_direction.Normalize();

        float dot_product = Vector3.Dot(player_direction, agent_direction);
        
        
        if(dot_product > 0.0f && agent.is_aggressive)
        {
            agent.stateMachine.ChangeState(AIStateID.ChasePlayer);
        }
        
    }
}
