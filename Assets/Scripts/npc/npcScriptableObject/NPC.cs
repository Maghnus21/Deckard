using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NPC", menuName = "NPC")]
public class NPC : ScriptableObject
{
    //  name of npc
    public string npc_name = "anon";

    //  health of npc
    public float health = 100f;

    //  walking speed of npc
    public float walking_speed = 3f;

    //  running speed of npc
    public float running_speed = 7f;

    //  model of npc
    public GameObject npc_model;

    //  model used for when npc is gibbed
    public GameObject gib_model;

    //  this is the dialogue npc will say
    public DialogueScriptableObject dialogue;
}
