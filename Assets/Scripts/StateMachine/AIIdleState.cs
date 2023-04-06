using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using UnityEngine;

public class AIIdleState : AIState
{
    public void Enter(AIAgent agent)
    {
        Debug.Log(agent.name + " entered state: AIIdleState");

        //agent.ai_weapon.enabled = false;
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
       
        
        if(agent.is_aggressive)
        {
            if (agent.ai_weapon.equipted_gun != null)
                agent.stateMachine.ChangeState(AIStateID.AttackPlayer);

            else 
            { 
                agent.stateMachine.ChangeState(AIStateID.FindWeapon);
            }
        }
        
    }
}
