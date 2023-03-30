using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public PlayerHotkeys player_hot_key;
    public GameObject player;

    private void Start()
    {
        player_hot_key = player.GetComponent<PlayerHotkeys>();
    }

    private void Update()
    {
        if (player_hot_key.current_held_item)
        {
            if(player_hot_key.equipted_item != null && player_hot_key.equipted_item.is_throwable) { }


            if (player_hot_key.equipted_item != null && player_hot_key.equipted_item.is_melee_weapon) { }

            else
            {
                if (Input.GetMouseButtonDown(0)) player_hot_key.current_held_item.GetComponent<FireWeapon>().FireGun();

                if (Input.GetMouseButton(1)) player_hot_key.current_held_item.GetComponent<FireWeapon>().Aim(true);
                else player_hot_key.current_held_item.GetComponent<FireWeapon>().Aim(false);
            }
            
        }
        
    }
}
