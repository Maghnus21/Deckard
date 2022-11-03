using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Gun", menuName ="Gun")]
public class Gun : ScriptableObject
{
    // scriptable objsct script to contain data for multiple other weapons that share the same variables

    //  name of gun
    public string name;

    //  reference to gun prefab
    public GameObject gun_prefab;

    //  reference to bullet
    public GameObject bullet;

    // aim speed
    public float ads_speed;

    //  speed of bullet
    public float bullet_speed;

    // speed of weapon rotation after firing [LOWER IS SLOWER];
    public float recoilRotationSpeed;

    // speed of weapon rotation returning to default position [LOWER IS SLOWER]
    public float recoilRotationReturn;

    // Amount of recoil experienced
    // x is upward directional force, not randomaly decided
    // y and z are randomaly decided with random.range function
    public Vector3 recoilRotation = new Vector3(10f, 5f, 7f);

}
