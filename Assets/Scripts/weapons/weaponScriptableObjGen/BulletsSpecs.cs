using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet Specs", menuName = "Bullet Specs")]
public class BulletsSpecs : ScriptableObject
{
    public float bullet_damage = 20f;

    //  default value set to 300
    public float bullet_velocity = 300f;

    //  default value set as 0
    public float bullet_drop = 0f;

    public GameObject bullet_shape;
}
