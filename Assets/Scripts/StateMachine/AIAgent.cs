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
    public AIWeapon ai_weapon;
    public GameObject IK_gameobject_transform;
    public Item available_gun;
    public DialogueTreeScriptableObject dialogue_tree;
    public InterrogationDialogueTreeScriptableObject interrogation_dialogue_tree;
    public Vector3 impact_direction;
    public Rigidbody hit_rb;
    public MeshSockets mesh_sockets;
    public AIWeaponIK ai_weapon_ik;
    public AudioSource npc_audio_source;
    public AudioClip npc_aggression_audio;
    public EnemyLOS npc_los;
    public NPCBoxTrigger npc_box_trigger;

    GameObject cloned_npc_gun;

    public float aggression_level;
    public bool is_aggressive = false;


    public List<AIAgent> agents = new List<AIAgent>();

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        ragdoll = GetComponent<Ragdoll>();
        health = GetComponent<Health>();
        ai_weapon = GetComponent<AIWeapon>();
        mesh_sockets = GetComponent<MeshSockets>();
        ai_weapon_ik = GetComponent<AIWeaponIK>();
        npc_los = GetComponent<EnemyLOS>();
        npc_box_trigger = GetComponentInChildren<NPCBoxTrigger>();
        //weaponIK = GetComponent<AIWeaponIK>();
        //head_tracking = GetComponent<AIHeadBone>();
        //mesh_socket = GetComponentInChildren<MeshSocket>();
        player_gameobject = GameObject.FindGameObjectWithTag("Player");

        

        if (player_transform == null)
        {
            player_transform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        stateMachine = new AIStateMachine(this);

        stateMachine.RegisterState(new AIIdleState());
        stateMachine.RegisterState(new AIChasePlayerState());
        stateMachine.RegisterState(new AIFindWeaponState());
        stateMachine.RegisterState(new AIDeathState());
        stateMachine.RegisterState(new AIAttackPlayerState());

        stateMachine.ChangeState(initialState);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        stateMachine.Update();
    }
}
