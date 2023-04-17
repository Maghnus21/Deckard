using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public PlayerInventory player_hot_key;
    public GameObject player;
    public FireWeapon active_player_weapon;
    public WeaponRecoil active_player_weapon_recoil;


    public float delay_time = 4f;
    public float throw_force = 3f;

    float next_round = 0;

    private void Start()
    {
        player_hot_key = player.GetComponent<PlayerInventory>();
        
    }

    private void Update()
    {
        if (player_hot_key.current_held_item)
        {
            

            if (player_hot_key.equipted_item != null && player_hot_key.equipted_item.is_throwable) {
                if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.Tab))
                {
                    GameObject throwable = Instantiate(player_hot_key.equipted_item.weapon_prefab, Camera.main.transform.position, Camera.main.transform.rotation) as GameObject;

                    throwable.GetComponent<Rigidbody>().isKinematic = false;
                    throwable.GetComponent<MeshCollider>().enabled = true;
                    throwable.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * throw_force, ForceMode.Impulse);

                    throwable.GetComponent<explosiveHealth>().Invoke("detonate", delay_time);
                }
            }
            


            if (player_hot_key.equipted_item != null && player_hot_key.equipted_item.is_melee_weapon) { }

            if(player_hot_key.equipted_item != null && !player_hot_key.equipted_item.is_melee_weapon && !player_hot_key.equipted_item.is_throwable)
            {
                active_player_weapon = player_hot_key.current_held_item.GetComponent<FireWeapon>();

                float fire_rate = 60f / active_player_weapon.weapon_stats.weapon_specs.fire_rate;
                /*
                if (Input.GetMouseButtonDown(0))
                { 
                    active_player_weapon.StartFiring();
                    active_player_weapon.DisplayAmmoCount();
                }
                */

                int rounds_left = active_player_weapon.weapon_stats.weapon_specs.magazine_size - active_player_weapon.weapon_stats.weapon_specs.bullets_fired;

                if (Input.GetMouseButton(0) && !Input.GetKey(KeyCode.Tab))
                {
                    if (rounds_left > 0 && Time.time > next_round)
                    {
                        next_round = Time.time + fire_rate;
                        active_player_weapon.FirePlayerBullet();
                        if (player_hot_key.current_held_item.GetComponent<WeaponAnimations>()) player_hot_key.current_held_item.GetComponent<WeaponAnimations>().PlayFireAnimation();

                        active_player_weapon.weapon_stats.weapon_specs.bullets_fired++;

                        active_player_weapon.DisplayAmmoCount();
                    }
                }

                if(Input.GetMouseButtonDown(0) && rounds_left <= 0 && !Input.GetKey(KeyCode.Tab))
                {
                    print("WEAPON OUT OF BULLETS");
                }

                if (Input.GetKeyDown(KeyCode.R))
                {
                    if (active_player_weapon.weapon_stats.weapon_specs.magazine_size - active_player_weapon.weapon_stats.weapon_specs.bullets_fired == active_player_weapon.weapon_stats.weapon_specs.magazine_size)
                        return;

                    if (player_hot_key.current_held_item.GetComponent<WeaponAnimations>()) player_hot_key.current_held_item.GetComponent<WeaponAnimations>().PlayReloadAnimation();
                    else active_player_weapon.ReloadWeapon();
                    print("RELOADED WEAPON");
                }

                

                if (active_player_weapon.is_firing) active_player_weapon.UpdateFiring(Time.deltaTime);
                
                //if (Input.GetMouseButtonUp(0)) active_player_weapon.StopFiring();
                active_player_weapon.UpdatePlayerWeapon(Time.deltaTime);

                active_player_weapon_recoil = player_hot_key.current_held_item.GetComponent<WeaponRecoil>();
                
                if (Input.GetMouseButton(1)) active_player_weapon_recoil.Aim(true);
                else active_player_weapon_recoil.Aim(false);
                
            }
            
        }

        

    }
}
