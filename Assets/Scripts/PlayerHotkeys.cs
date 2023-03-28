using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHotkeys : MonoBehaviour
{
    public Gun[] loadout = new Gun[10];
    //  current actuve Gun Scriptable Object
    public Gun equipted_gun;

    //  weapon held by player
    GameObject current_weapon = null;


    //  object references to be parsed to weapons
    [Header("Objects only parsed to weapons")]
    public Camera main_cam;
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
    }


    void EquipWeapon(int index_num)
    {
        //  if array index is empty, output error of no gun in array index
        if (loadout[index_num] == null) { print("NO WEAPON IN GUN ARRAY INDEX " + index_num); return; }

        //  if player has equipted tried equiping same weapon, says weapon already equipted
        if (equipted_gun == loadout[index_num]) print("Weapon " + equipted_gun.name + " already equipted");

        //  populates equipted_gun with Gun Scriptable Object and populates current_gun weapon weapon prefab using equipted_gun
        if (equipted_gun != loadout[index_num])
        {
            equipted_gun = loadout[index_num];

            if(equipted_gun.is_melee_weapon || equipted_gun.is_throwable) current_weapon = equipted_gun.weapon_prefab;


            else current_weapon = equipted_gun.gun_prefab;
        }


        //  instanciate weapon and add data from equipted_weapon to it if necessary
        
    }
}
