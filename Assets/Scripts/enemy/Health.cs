using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
    public NPC npc;                             //  contains data etc health
    Ragdoll ragdoll;                            //  controlls ragdoll effects for entity
    AIAgent agent;
    Rigidbody[] rigidbodies;

    public float impact_force = 20f;            //  default force applied to entity when hit with killing bullet

    public float health;


    //  scripts for npc movement
    NavMeshAgent npc_agent;
    AINavigation npc_nav;
    Animator animator;

    BranchDialogueTest bdt;

    

    /// <summary>
    /// if assigned true, gameObject mass included in ragdoll physics. if assigned false, ragdoll mass is ignored. default is true
    /// </summary>
    public bool death_force_mode = true;

    void Awake()
    {
        Random.seed = (int)System.DateTime.Now.Ticks;


        if(npc != null)
        {
            health = npc.health;

            ragdoll = GetComponent<Ragdoll>();

            CreateEntityRagdoll();
        }
        else
        {
            health = 10f;
        }

        agent = GetComponent<AIAgent>();

        assignScripts();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Function called when bone gameObject containing script EntityHitbox hit with bullet.
    /// </summary>
    /// <param name="amount">passes damage amount</param>
    /// <param name="impact_direction">the direction of impact received from bullet prefab ray</param>
    /// <param name="hit_rb">bone gameObject with rigidbody that was hit by RaycastHit passed via hit.rigidbody</param>
    public void ReceiveDamage(float amount, Vector3 impact_direction, Rigidbody hit_rb)
    {
        health -= amount;
        if(health <= 0 && npc != null)
        {
            Die(impact_direction, hit_rb);
        }
    }

    public void ReceiveExplosiveDamage(float damage, Vector3 det_loc, float exp_force, float exp_rad, float exp_up)
    {
        health -= damage;
        if(health <= 0 && npc != null)
        {
            ExplosiveDie(det_loc, exp_force, exp_rad, exp_up);
        }
    }

    /// <summary>
    /// Function called when health value reaches or below threshold, 0
    /// </summary>
    /// <param name="impact_direction">direction of impact. must be passed via ray.direction</param>
    /// <param name="hit_rb">bone gameObject with rigidbody that was hit by RaycastHit passed via hit.rigidbody</param>
    void Die(Vector3 impact_direction, Rigidbody hit_rb)
    {

        
        disableScripts();



        float gib_chance_mutiplier = 0 - health;
        float rand_num = Random.Range(0f, 100f);

        if(rand_num <= gib_chance_mutiplier)
        {
            
            Instantiate(npc.gib_model, transform.position, transform.rotation);

            Destroy(this.gameObject);
        }
        else
        {
            AIDeathState deathState = agent.stateMachine.getState(AIStateID.Death) as AIDeathState;
            GetComponent<AIAgent>().impact_direction = impact_direction;
            GetComponent<AIAgent>().hit_rb = hit_rb;
            agent.stateMachine.ChangeState(AIStateID.Death);

            foreach (Rigidbody rb in rigidbodies)
            {
                rb.tag = "EntityDead";
            }
        }
    }

    void ExplosiveDie(Vector3 det_loc, float exp_force, float exp_rad, float exp_up)
    {

        disableScripts();

        float rand = Random.Range(0f, 100f);

        
        if(rand < 50)
        {
            GameObject gib_body = Instantiate(npc.gib_model, transform.position, transform.rotation);
            
            Rigidbody[] rb = gib_body.GetComponentsInChildren<Rigidbody>();

            foreach(Rigidbody rb2 in rb)
            {
                rb2.AddExplosionForce(exp_force, det_loc, exp_rad, exp_up, ForceMode.Impulse);
            }


            Destroy(this.gameObject);
        }
        else
        {
            ragdoll.ActivateRagdoll();
            ragdoll.AddExplosiveForcePoint(det_loc, exp_force, exp_rad, exp_up, true);

            foreach (Rigidbody rb in rigidbodies)
            {
                rb.tag = "EntityDead";
            }

            
        }
    }

    void CreateEntityRagdoll()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in rigidbodies)
        {
            EntityHitbox entity_hitbox;


            //  split into if statemment to prevent adding second hitbox to enemy rigidbody if previously added for weak-points
            if (!rb.GetComponent<EntityHitbox>())
            {
                entity_hitbox = rb.gameObject.AddComponent<EntityHitbox>();
                entity_hitbox.health = this;                                                //  health values for entity_hitbox equal to health value of Health.cs
            }
            else
            {
                rb.GetComponent<EntityHitbox>().health = this;
            }
        }
            
    }

    //  this method use is solely for turning off scripts if npc has died/entered a ragdoll state
    void disableScripts()
    {
        npc_agent.enabled = false;
        npc_nav.enabled = false;
        animator.enabled = false;
    }

    //  method only used for assigning scripts to npc specific fields
    void assignScripts()
    {
        if (GetComponent<NavMeshAgent>())
        {
            npc_agent = GetComponent<NavMeshAgent>();
        }
        if (GetComponent<AINavigation>())
        {
            npc_nav = GetComponent<AINavigation>();
        }
        if (GetComponent<Animator>())
        {
            animator = GetComponent<Animator>();
        }
        /*
        if (GetComponent<NPCBehaviour>())
        {
            npc_behaviour = GetComponent<NPCBehaviour>();
        }
        */
        if (GetComponent<BranchDialogueTest>())
        {
            bdt = GetComponent<BranchDialogueTest>();
        }
    }
}
