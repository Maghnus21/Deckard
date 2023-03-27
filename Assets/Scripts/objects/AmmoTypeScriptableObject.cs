using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ammo Type", menuName = "Ammo Type")]
public class AmmoTypeScriptableObject : ScriptableObject
{
    public string ammo_type;
    public int ammo_max_capacity;
    public int current_ammo_count;
}
