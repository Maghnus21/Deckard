using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Specs", menuName = "Weapon Specs")]
public class WeaponSpecs : ScriptableObject
{
    public int fire_rate = 600;

    public int magazine_size = 30;

    //  reference to BulletSpecs scriptable object
    public BulletsSpecs bullet_type;

    //  number of bullets gun will fire with each button press
    public int number_of_bullets = 1;

    //  player only value
    public int bullets_fired = 0;

    //  player only value
    public int ammo_reserve = 0;

    //  player only value
    public int max_ammo_reserve = 200;

    public Vector3 bullet_spread = new Vector3(.1f, .1f, .1f);

    //  if set as false, weapon should be fired as semi-automatic
    public bool is_full_automatic = false;

    // Amount of recoil experienced
    // x is upward directional force, not randomaly decided
    // y and z are randomaly decided with random.range function
    // present values will act as default
    public Vector3 recoil_rotation = new Vector3(5, 4, 6);

    // speed of weapon rotation after firing [LOWER IS SLOWER];
    public int recoil_speed = 40;

    // speed of weapon rotation returning to default position [LOWER IS SLOWER]
    public int recoil_return = 3;

}
