using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoBoxPickup : MonoBehaviour
{
    public Item weapon_scriptable_object;
    public float ammo_refil = 20;
    public int stack_location;
    // Start is called before the first frame update
    void Start()
    {
        stack_location = weapon_scriptable_object.stack_location;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            /*
            if (other.gameObject.GetComponent<weapon>().loadout[stack_location].ammo_reserve < 999 - ammo_refil)
            {
                other.gameObject.GetComponent<weapon>().loadout[stack_location].ammo_reserve += ammo_refil;
                other.gameObject.GetComponent<weapon>().DisplayAmmoCount();
                Destroy(gameObject);
            }
            else if (other.gameObject.GetComponent<weapon>().loadout[stack_location].ammo_reserve > 999 - ammo_refil && other.gameObject.GetComponent<weapon>().loadout[stack_location].ammo_reserve < 999)
            {
                //other.gameObject.GetComponent<weapon>().loadout[stack_location].ammo_reserve = 999;
                other.gameObject.GetComponent<weapon>().DisplayAmmoCount();
                Destroy(gameObject);
            }
            */
        }
    }
}
