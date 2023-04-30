using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Item[] loadout = new Item[10];
    //  current actuve Gun Scriptable Object
    public Item equipted_item;
    public Transform hand_point;

    //  weapon held by player
    public GameObject current_held_item = null;

    [Header("Player Inventory")]
    public List<Item> player_inventory = new List<Item>();

    public Item medipen_amount;

    public AudioClip injector;

    [Header("Managers")]
    public UIManager ui_man;
    public AudioManager audio_man;

    [Header("Player script references")]
    public playerHealth player_health;
    public AudioSource player_source;


    //  object references to be parsed to weapons
    [Header("Objects only parsed to weapons")]
    public Transform main_cam;
    public Transform player_chest;
    public ParticleSystem bullet_impact_effect;
    public Transform raycast_destination;
    public TextMeshProUGUI ammo_text;
    public PlayerGun player_gun;
    public TextMeshProUGUI ammo_count;
    public GameObject weapon_wheel_ui;


    WeaponWheelButton[] wwbs;


    // Start is called before the first frame update
    void Start()
    {
        ui_man = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();

        player_gun = GetComponent<PlayerGun>();
        player_gun.enabled = false;

        player_health = GetComponent<playerHealth>();
        player_source = GetComponentInChildren<AudioSource>();

        wwbs = weapon_wheel_ui.GetComponentsInChildren<WeaponWheelButton>();

        ui_man.UpdateMedipenDisplay("medipen_count: [" + medipen_amount.item_amount + "]");

        AssignWWSprites();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1) && loadout[0] != null)
            EquipWeapon(0);
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
            EquipWeapon(1);
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
            EquipWeapon(2);
        
        if (Input.GetKeyDown(KeyCode.Alpha4))
            EquipWeapon(3);
        
        if (Input.GetKeyDown(KeyCode.Alpha5))
            EquipWeapon(4);
        
        if (Input.GetKeyDown(KeyCode.Alpha6))
            EquipWeapon(5);
        
        if (Input.GetKeyDown(KeyCode.Alpha7))
            EquipWeapon(6);
        
        if (Input.GetKeyDown(KeyCode.Alpha8))
            EquipWeapon(7);
        
        if (Input.GetKeyDown(KeyCode.Alpha9))
            EquipWeapon(8);
        
        if (Input.GetKeyDown(KeyCode.Alpha0))
            EquipWeapon(9);


        if (Input.GetKeyDown(KeyCode.V) && equipted_item != null)
            UnequipWeapon();

        if (Input.GetKeyDown(KeyCode.H))
            UseMediPen();

        /*
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Physics.Raycast(ray, out hit, 5f) && hit.collider.GetComponentInParent<ItemPickup>() && hit.collider.GetComponentInParent<ItemPickup>().enabled)
                hit.collider.GetComponentInParent<ItemPickup>().PickUpItem(this);



        }
        */

        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if (Input.GetKeyDown(KeyCode.F))
            if (Physics.Raycast(ray, out hit, 5f))
            { 
                if (hit.collider.GetComponent<KeyCheck>())
                    CheckKeys(hit.collider.GetComponent<KeyCheck>());
                if (hit.collider.GetComponent<ItemDeposit>())
                    hit.collider.GetComponent<ItemDeposit>().DepositItem(player_inventory);
            }
    }

    private void UseMediPen()
    {
        if (medipen_amount.item_amount > 0 && player_health.health < 100f)
        {
            medipen_amount.item_amount--;

            ui_man.UpdateMedipenDisplay("medipen_count: [" + medipen_amount.item_amount + "]");

            float remainder_hp = 100f - player_health.health;
            player_health.PlayerHeal(35f);
            //ui_man.DisplayPlainText("used: [MEDIPEN]");
            audio_man.PlaySound(player_source, injector);
        }
        else if(medipen_amount.item_amount == 0)
            ui_man.DisplayPlainText("medipen_count: [DEPLETED]");
    }

    public void UpdateMedipenCount()
    {
        medipen_amount.item_amount++;
        ui_man.UpdateMedipenDisplay("medipen_count: [" + medipen_amount.item_amount + "]");
    }

    public void EquipWeapon(int index_num)
    {
        

        //  if array index is empty, output error of no gun in array index
        if (loadout[index_num] == null) { print("NO WEAPON IN GUN ARRAY INDEX " + index_num); return; }

        //  if player has equipted tried equiping same weapon, says weapon already equipted
        if (equipted_item == loadout[index_num]) print("Weapon " + equipted_item.name + " already equipted");

        //  populates equipted_gun with Gun Scriptable Object and populates current_gun weapon weapon prefab using equipted_gun
        if (equipted_item != loadout[index_num])
        {
            UnequipWeapon();
            player_gun.enabled = true;

            equipted_item = loadout[index_num];


            if (equipted_item.is_melee_weapon || equipted_item.is_throwable) current_held_item = Instantiate(equipted_item.weapon_prefab, hand_point) as GameObject;


            else
            {
                current_held_item = Instantiate(equipted_item.item_prefab, hand_point) as GameObject;
 
                current_held_item.GetComponent<FireWeapon>().raycast_destination = raycast_destination;
                current_held_item.GetComponent<FireWeapon>().hit_effect = bullet_impact_effect;
                current_held_item.GetComponent<WeaponRecoil>().main_camera = main_cam;
                current_held_item.GetComponent<WeaponRecoil>().player_chest = player_chest;
                current_held_item.GetComponent<FireWeapon>().ammo_display = ammo_count;

                current_held_item.GetComponent<FireWeapon>().DisplayAmmoCount();
            }
        }
    }

    void UnequipWeapon()
    {
        player_gun.enabled = false;

        equipted_item = null;
        Destroy(current_held_item);
        current_held_item = null;

        print("Unequiped weapon");
    }

    public void AddItemToInv(Item item)
    {
        print("Added " + item.name + " to player inventory");
        player_inventory.Add(item);
    }

    public void RemoveItemFromInv(Item item)
    {
        foreach (Item item2 in player_inventory)
            if (item2.name == item.name)
                player_inventory.Remove(item2);
        
    }

    public void AssignWWSprites()
    {
        foreach(WeaponWheelButton wwb in wwbs)
        {
            for (int i = 0; i < loadout.Length; i++)
            {
                if (loadout[i].stack_location == wwb.stack_location)
                {
                    wwb.button_image.sprite = loadout[i].ui_sprite;
                }
                else i++;
            }
        }
    }

    void CheckKeys(KeyCheck key_check)
    {
        bool opened_door = false;

        foreach (Item item in player_inventory)
        {
            print("checking inventory");
            if (item.is_key == true && item.keycode == key_check.keycode)
            {
                print("ACCEPTED KEY");
                opened_door = true;
            }
            else opened_door = false;
        }
            

        key_check.CheckKeycode(opened_door);
        
    }
}
