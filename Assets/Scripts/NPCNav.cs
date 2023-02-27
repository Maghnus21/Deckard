using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCNav : MonoBehaviour
{
    Transform npc_move_transform;

    NavMeshAgent npc_nav_mesh;

    // Start is called before the first frame update
    void Start()
    {
        npc_move_transform = GameObject.Find("player").transform;
        npc_nav_mesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<NPCBehaviour>().is_hostile)
        {
            npc_nav_mesh.destination = npc_move_transform.position;
        }
        else { }
    }
}
