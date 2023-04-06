using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrolState : AIState
{
    public void Enter(AIAgent agent)
    {
        Debug.Log(agent.name + " entered state: AIPatrolState");
    }

    public void Exit(AIAgent agent)
    {
        
    }

    public AIStateID getID()
    {
        return AIStateID.Patrol;
    }

    public void Update(AIAgent agent)
    {
        
    }

    
}
