using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAgent : MonoBehaviour
{
    public AIStateMachine stateMachine;
    public AIStateID initialState;
    public NavMeshAgent navMeshAgent;
    public AIAgentConfig config;
    public Ragdoll ragdoll;
    public Health health;
    public Transform player_transform;
    public GameObject player_gameobject;
    public BranchDialogueTest branch_dialogue;
    public AINavigation ai_nav;
    public AIWeapon weapon;
    public AIWeaponIK weaponIK;
    public GameObject IK_gameobject_transform;

    public bool is_aggressive = false;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        ragdoll = GetComponent<Ragdoll>();
        health = GetComponent<Health>();
        weapon = GetComponent<AIWeapon>();
        weaponIK = GetComponent<AIWeaponIK>();
        player_gameobject = GameObject.FindGameObjectWithTag("Player");

        if (player_transform == null)
        {
            player_transform = GameObject.FindGameObjectWithTag("Player").transform;
        }


        stateMachine = new AIStateMachine(this);

        stateMachine.RegisterState(new AIIdleState());
        stateMachine.RegisterState(new AIChasePlayerState());
        stateMachine.RegisterState(new AIFindWeaponState());
        stateMachine.RegisterState(new AIAttackPlayerState());
        stateMachine.RegisterState(new AIDeathState());
        

        stateMachine.ChangeState(initialState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }
}
