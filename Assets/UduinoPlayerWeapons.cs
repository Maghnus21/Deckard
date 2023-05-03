using System.Collections;
using System.Collections.Generic;
using Uduino;
using UnityEngine;

public class UduinoPlayerWeapons : MonoBehaviour
{
    public PlayerInventory player_inv;
    public PlayerGun player_gun;

    bool pressed_weapon_switch_button = false;

    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        UduinoManager.Instance.pinMode(2, PinMode.Input_pullup);
        UduinoManager.Instance.pinMode(5, PinMode.Input_pullup);
    }

    // Update is called once per frame
    void Update()
    {
        if(UduinoManager.Instance.digitalRead(2) == 0 && !pressed_weapon_switch_button)
        {
            if (i > player_inv.loadout.Length)
                i = 0;

            player_inv.EquipWeapon(i);
            i++;

            pressed_weapon_switch_button = true;
        }

        if (UduinoManager.Instance.digitalRead(2) == 1)
            pressed_weapon_switch_button = false;

        if (UduinoManager.Instance.digitalRead(5) == 1 && player_gun.player_hot_key.equipted_item != null && 
            !player_gun.player_hot_key.equipted_item.is_melee_weapon && !player_gun.player_hot_key.equipted_item.is_throwable)
            player_gun.uduino_con_fire = true;
        else
            player_gun.uduino_con_fire = false;
    }
}
