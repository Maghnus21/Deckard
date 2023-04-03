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
    public AINavigation ai_nav;
    public AIWeapon weapon;
    public AIWeaponIK weaponIK;
    public MeshSocket mesh_socket;
    public GameObject IK_gameobject_transform;
    public AIHeadBone head_tracking;
    public Item available_gun;
    public DialogueTreeScriptableObject dialogue_tree;
    public InterrogationDialogueTree interrogation_dialogue_tree;
    public Vector3 impact_direction;
    public Rigidbody hit_rb;

    GameObject cloned_npc_gun;

    public float aggression_level;
    public bool is_aggressive = false;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        ragdoll = GetComponent<Ragdoll>();
        health = GetComponent<Health>();
        weapon = GetComponent<AIWeapon>();
        weaponIK = GetComponent<AIWeaponIK>();
        head_tracking = GetComponent<AIHeadBone>();
        mesh_socket = GetComponentInChildren<MeshSocket>();
        player_gameobject = GameObject.FindGameObjectWithTag("Player");

        

        if (player_transform == null)
        {
            player_transform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        //  checks for any dialogue components attached to entity.
        //  interrogationDialogueTree is used solely for suspects
        if (GetComponent<InterrogationDialogueTree>())
        {
            interrogation_dialogue_tree = GetComponent<InterrogationDialogueTree>();
        }


        stateMachine = new AIStateMachine(this);

        stateMachine.RegisterState(new AIIdleState());
        stateMachine.RegisterState(new AIChasePlayerState());
        stateMachine.RegisterState(new AIFindWeaponState());
        stateMachine.RegisterState(new AIAttackPlayerState());
        stateMachine.RegisterState(new AIDeathState());
        stateMachine.RegisterState(new AIWeaponActive());
        

        stateMachine.ChangeState(initialState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }

    public GameObject CloneNPCGun()
    {
        cloned_npc_gun = Instantiate(available_gun.gun_npc, transform.position, transform.rotation);
        return cloned_npc_gun;
    }

    public void DisableScripts()
    {
        if(weapon.enabled)
            weapon.enabled = false;

        if(weaponIK.enabled)
            weaponIK.enabled = false;

        if(head_tracking.enabled)
            head_tracking.enabled = false;

        if(ai_nav.enabled)
            ai_nav.enabled = false;
    }
}
