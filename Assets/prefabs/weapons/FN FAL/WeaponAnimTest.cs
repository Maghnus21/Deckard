using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimTest : MonoBehaviour
{

    public Animator gun_anim;

    // Start is called before the first frame update
    void Start()
    {
        if(GetComponentInChildren<Animator>() && !GetComponentInChildren<Animator>().enabled)
            this.enabled = false;

        gun_anim = GetComponentInChildren<Animator>();

        gun_anim.Play("Idle");
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButton(0))
        {
            gun_anim.SetTrigger("fire");
            GetComponent<FireWeapon>().can_fire = false;
        }
        else


        if (Input.GetKeyDown(KeyCode.R))
        {

            gun_anim.SetTrigger("reload");
        }
    }



}
