using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NPC", menuName = "NPC")]
public class NPC : ScriptableObject
{
    //  health of npc
    public float health = 100f;

    //  walking speed of npc
    public float walking_speed = 3f;

    //  running speed of npc
    public float running_speed = 7f;

    //  model of npc
    public GameObject npc_model;
}
