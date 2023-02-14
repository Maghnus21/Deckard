using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponWheel : MonoBehaviour
{
    public Canvas weapon_wheel;
    public WeaponWheelButton[] weapon_wheel_buttons;


    // Start is called before the first frame update
    void Start()
    {
        weapon_wheel.enabled = false;        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            weapon_wheel.enabled = true;
            gameObject.GetComponentInChildren<player_look>().enabled = false;
        }
        else
        {
            weapon_wheel.enabled = false;
            gameObject.GetComponentInChildren<player_look>().enabled = true;
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
