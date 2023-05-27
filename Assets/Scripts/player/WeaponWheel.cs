using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponWheel : MonoBehaviour
{
    public Canvas weapon_wheel;
    public WeaponWheelButton[] weapon_wheel_buttons;

    public PlayerGun player_gun;

    public bool pressed_tab = false;


    // Start is called before the first frame update
    void Start()
    {
        weapon_wheel.enabled = false;
        
        player_gun = GetComponent<PlayerGun>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            pressed_tab = true;
            Cursor.visible = true;

            weapon_wheel.enabled = true;
            player_gun.enabled = false;

            if (Input.GetMouseButton(1))
                gameObject.GetComponentInChildren<player_look>().enabled = true;
            else
                gameObject.GetComponentInChildren<player_look>().enabled = false;
        }
        else
        {
            weapon_wheel.enabled = false;
            gameObject.GetComponentInChildren<player_look>().enabled = true;
            player_gun.enabled = true;

            if(pressed_tab)
            {
                Cursor.visible = false;
                pressed_tab = false;
            }
        }
    }


    public void updateWWUI(Sprite weapon_image)
    {
        foreach(WeaponWheelButton weaponWheelButton in weapon_wheel_buttons)
        {
            if(weaponWheelButton.button_image == null)
            {
                weaponWheelButton.GetComponentInChildren<Image>().sprite = weapon_image;
                break;
            }
            else { }
        }
    }
}
