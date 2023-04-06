using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIPatrolPoints : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] patrol_points;
    int point_num = 0;

    int sneed = 0;

    float time = 0f;
    float loiter_time = 3f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        NPCPatrol();
    }

    public void NPCPatrol()
    {
        

        if (agent.transform.position == patrol_points[point_num].position && patrol_points.Length > 0)
        {
            point_num++;
            if(point_num >= patrol_points.Length) point_num = 0;

            Vector3 npc_destination = new Vector3(patrol_points[point_num].position.x, transform.position.y, patrol_points[point_num].position.z);

            agent.SetDestination(npc_destination);
        }
    }

    
}
