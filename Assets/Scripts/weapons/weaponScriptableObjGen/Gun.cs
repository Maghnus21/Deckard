using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Gun", menuName ="Gun")]
public class Gun : ScriptableObject
{
    // scriptable objsct script to contain data for multiple other weapons that share the same variables
    public string name;
    public GameObject gun_prefab;
    public float ads_speed;
    public float bullet_speed;
    public GameObject bullet;
}
