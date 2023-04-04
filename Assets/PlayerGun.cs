using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public PlayerHotkeys player_hot_key;
    public GameObject player;
    public FireWeapon active_player_weapon;
    public WeaponRecoil active_player_weapon_recoil;


    public float delay_time = 4f;
    public float throw_force = 3f;

    private void Start()
    {
        player_hot_key = player.GetComponent<PlayerHotkeys>();
        
    }

    private void LateUpdate()
    {
        if (player_hot_key.current_held_item)
        {
            

            if (player_hot_key.equipted_item != null && player_hot_key.equipted_item.is_throwable) {
                if (Input.GetMouseButtonDown(0))
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

                if (Input.GetMouseButtonDown(0)) active_player_weapon.StartFiring();
                
                if (active_player_weapon.is_firing) active_player_weapon.UpdateFiring(Time.deltaTime);
                
                if (Input.GetMouseButtonUp(0)) active_player_weapon.StopFiring();
                active_player_weapon.UpdateBullets(Time.deltaTime);

                active_player_weapon_recoil = player_hot_key.current_held_item.GetComponent<WeaponRecoil>();
                
                if (Input.GetMouseButton(1)) active_player_weapon_recoil.Aim(true);
                else active_player_weapon_recoil.Aim(false);
                
            }
            
        }

        

    }
}
