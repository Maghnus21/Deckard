using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLOS : MonoBehaviour
{
    [Range(0.1f, 1f)]
    public float polling_time = 1f;

    Transform player;
    public Transform npc_eyes;

    public NPCBoxTrigger box_trigger;

    Ray ray;
    RaycastHit hit;

    public bool has_los = false;
    bool player_is_target = false;

    public bool attack_on_sight = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (GetComponentInChildren<NPCBoxTrigger>())
            box_trigger = GetComponentInChildren<NPCBoxTrigger>();

        StartCoroutine(CheckLOS(polling_time));
    }

    // Update is called once per frame
    void Update()
    {
        /*
        ray = new Ray(npc_eyes.transform.position, player.transform.position - npc_eyes.transform.position);

        if(Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Player") ){
                print("SEING PLAYER");
            }
        }
        */
    }

    
    IEnumerator CheckLOS(float poll_rate)
    {
        while (true)
        {
            yield return new WaitForSeconds(poll_rate);

            ray = new Ray(npc_eyes.transform.position, player.transform.position - npc_eyes.transform.position);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Player"))
                    has_los = true;
                    //print("SEE PLAYER");

                else
                    has_los = false;
            }

            if (GetComponent<Health>().health > 0f)
            {
                if (has_los && box_trigger.in_trigger && attack_on_sight)
                {
                    player_is_target = true;
                    GetComponent<AIAgent>().stateMachine.ChangeState(AIStateID.AttackPlayer);
                }

                else if (!has_los && player_is_target)
                    GetComponent<AIAgent>().stateMachine.ChangeState(AIStateID.ChasePlayer);
            }
                

            

        }
        
    }
    
}
