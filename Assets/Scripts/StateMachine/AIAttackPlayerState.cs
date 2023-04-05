using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttackPlayerState : AIState
{
    float player_poling = .3f;
    float time;
    public void Enter(AIAgent agent)
    {
        Debug.Log(agent.name + " entered state: AIAttackPlayerState");

        agent.npc_audio_source.clip = agent.npc_aggression_audio;
        agent.npc_audio_source.Play();


        if (agent.ai_weapon.equipted_gun != null)
        {
            agent.ai_weapon.enabled = true;
            agent.ai_weapon.ActivateWeapon();
        }
        else agent.stateMachine.ChangeState(AIStateID.FindWeapon);
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
        if((time += Time.deltaTime) >= player_poling)
            agent.navMeshAgent.destination = agent.player_transform.position;

        if (agent.player_gameobject.GetComponent<playerHealth>().health <= 0)
            agent.stateMachine.ChangeState(AIStateID.Idle);
    }

    
}
