using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPickup : MonoBehaviour
{
    public BoxCollider trigger_col;
    public Item weapon_scriptable_object;
    public Image image;
    public GameObject button;
    WeaponWheelButton wwb;
    public int stack_location = 0;              //  default state is stack location 0

    private void Start()
    {
        button = weapon_scriptable_object.weapon_wheel_button;
        image = weapon_scriptable_object.weapon_wheel_button.GetComponentInChildren<Image>();
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            wwb = button.GetComponent<WeaponWheelButton>();
            if (other.GetComponent<weapon>().loadout[stack_location] == null)
            {
                other.GetComponent<weapon>().loadout[stack_location] = weapon_scriptable_object;

                image.GetComponent<Image>().sprite = other.GetComponent<weapon>().loadout[stack_location].ui_sprite;

                button.GetComponent<WeaponWheelButton>().stack_location = stack_location;

                Destroy(gameObject);


            }
            else if(other.GetComponent<weapon>().loadout[stack_location] != null && other.GetComponent<weapon>().loadout[stack_location].ammo_reserve < 999)
            {
                if(other.GetComponent<weapon>().loadout[stack_location].ammo_reserve + 20 > 999)
                {
                    other.GetComponent<weapon>().loadout[stack_location].ammo_reserve = 999;
                }
                else
                {
                    other.GetComponent<weapon>().loadout[stack_location].ammo_reserve += 20;
                }
                other.GetComponent<weapon>().DisplayAmmoCount();

                Destroy(gameObject);
            }
            else
            {

            }
        }

        if (other.CompareTag("NPC"))
        {
            EntityHitbox hitbox = other.gameObject.GetComponent<EntityHitbox>();
            if (hitbox)
            {
                AIWeapon weapons = hitbox.health.GetComponent<AIWeapon>();
                if(weapons != null && weapons.equipted_gun == null)
                {
                    //  places gun on npc back
                    weapons.EquiptWeapon(Instantiate(weapon_scriptable_object.gun_prefab) as GameObject);

                    Destroy(gameObject);
                }
            }
        }

    }
}
