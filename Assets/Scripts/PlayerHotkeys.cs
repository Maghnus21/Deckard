using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHotkeys : MonoBehaviour
{
    public Item[] loadout = new Item[10];
    //  current actuve Gun Scriptable Object
    public Item equipted_item;
    public Transform hand_point;

    //  weapon held by player
    GameObject current_held_item = null;


    //  object references to be parsed to weapons
    [Header("Objects only parsed to weapons")]
    public Transform main_cam;
    public Transform player_chest;
    public ParticleSystem bullet_impact_effect;
    public Transform raycast_destination;
    public TextMeshProUGUI ammo_text;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1) && loadout[0] != null)
        {
            EquipWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EquipWeapon(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            EquipWeapon(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            EquipWeapon(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            EquipWeapon(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            EquipWeapon(6);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            EquipWeapon(7);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            EquipWeapon(8);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            EquipWeapon(9);
        }


        if (Input.GetKeyDown(KeyCode.V) && equipted_item != null)
        {
            UnequipWeapon();
        }
    }


    void EquipWeapon(int index_num)
    {
        //  if array index is empty, output error of no gun in array index
        if (loadout[index_num] == null) { print("NO WEAPON IN GUN ARRAY INDEX " + index_num); return; }

        //  if player has equipted tried equiping same weapon, says weapon already equipted
        if (equipted_item == loadout[index_num]) print("Weapon " + equipted_item.name + " already equipted");

        //  populates equipted_gun with Gun Scriptable Object and populates current_gun weapon weapon prefab using equipted_gun
        if (equipted_item != loadout[index_num])
        {
            UnequipWeapon();


            equipted_item = loadout[index_num];


            if (equipted_item.is_melee_weapon || equipted_item.is_throwable) current_held_item = Instantiate(equipted_item.weapon_prefab, hand_point) as GameObject;


            else
            {
                current_held_item = Instantiate(equipted_item.gun_prefab, hand_point) as GameObject;
                current_held_item.GetComponent<FireWeapon>().player_chest = player_chest;
                current_held_item.GetComponent<FireWeapon>().main_camera = main_cam;
            }
        }
    }

    void UnequipWeapon()
    {
        equipted_item = null;
        Destroy(current_held_item);
        current_held_item = null;

        print("Unequiped weapon");
    }
}
