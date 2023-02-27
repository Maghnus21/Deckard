using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
    public NPC npc_status;

    public bool is_hostile;


    // Start is called before the first frame update
    void Start()
    {

        is_hostile = npc_status.is_hostile_to_player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
