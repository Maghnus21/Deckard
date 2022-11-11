using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    //  health of enemy
    public float health = 100f;

    //  walk speed of enemy
    public float walking_speed = 3f;

    //  run speed of enemy
    public float running_speed = 7f;

    //  model of enemy
    public GameObject enemy_model;

    //  prefab model of weapon
    public GameObject weapon_model;
}
