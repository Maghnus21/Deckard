using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public BoxCollider trigger_col;
    public Gun weapon_scriptable_object;
    public int stack_location = 0;              //  default state is stack location 0


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            
            if (other.GetComponent<weapon>().loadout[stack_location] == null)
            {
                other.GetComponent<weapon>().loadout[stack_location] = weapon_scriptable_object;





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
            }
            else
            {

            }
            

            Destroy(gameObject);


        }



    }
}
