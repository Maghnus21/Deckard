using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponWheel : MonoBehaviour
{
    public Canvas weapon_wheel;


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
}
