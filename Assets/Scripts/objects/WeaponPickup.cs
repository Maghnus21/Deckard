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
    PlayerInventory player_inv;

    public AudioManager audio_man;
    public AudioClip pickup;

    public UIManager ui_man;

    private void Start()
    {
        ui_man = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();

        button = weapon_scriptable_object.weapon_wheel_button;
        image = weapon_scriptable_object.weapon_wheel_button.GetComponentInChildren<Image>();

    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            //wwb = button.GetComponent<WeaponWheelButton>();
            player_inv = other.GetComponent<PlayerInventory>();

            player_inv.loadout[weapon_scriptable_object.stack_location] = weapon_scriptable_object;

            audio_man.PlaySound(other.GetComponentInChildren<AudioSource>(), pickup);
            ui_man.DisplayPickupItemText(weapon_scriptable_object);

            Destroy(gameObject);
            
        }

        if (other.CompareTag("NPC"))
        {
            print("NPC PICKUP");
            /*
            EntityHitbox hitbox = other.gameObject.GetComponent<EntityHitbox>();
            if (hitbox)
            {
                AIWeapon weapons = hitbox.health.GetComponent<AIWeapon>();
                if(weapons != null && weapons.equipted_gun == null)
                {
                    //  places gun on npc back
                    weapons.EquiptWeapon(Instantiate(weapon_scriptable_object.item_prefab) as GameObject);

                    Destroy(gameObject);
                }
            }
            */
        }

    }
}
