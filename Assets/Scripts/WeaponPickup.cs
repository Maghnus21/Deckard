using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPickup : MonoBehaviour
{
    public BoxCollider trigger_col;
    public Gun weapon_scriptable_object;
    public GameObject image;
    public GameObject button;
    public int stack_location = 0;              //  default state is stack location 0


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            
            if (other.GetComponent<weapon>().loadout[stack_location] == null)
            {
                other.GetComponent<weapon>().loadout[stack_location] = weapon_scriptable_object;

                image.GetComponent<Image>().sprite = other.GetComponent<weapon>().loadout[stack_location].gun_sprite;

                button.GetComponent<WeaponWheelButton>().stack_location = stack_location;

                Destroy(gameObject);


            }
            else if(other.GetComponent<weapon>().loadout[stack_location] != null && other.GetComponent<weapon>().loadout[stack_location].ammo_reserve < 999)
            {
                if(other.GetComponent<weapon>().loadout[stack_location].ammo_reserve + 20 > 999)
                {
                    other.GetComponent<weapon>().loadout[stack_location].ammo_reserve = 999;
                }
                else
                {
                    other.GetComponent<weapon>().loadout[stack_location].ammo_reserve += 20;
                }
                other.GetComponent<weapon>().DisplayAmmoCount();

                Destroy(gameObject);
            }
            else
            {

            }
            

            


        }



    }
}
