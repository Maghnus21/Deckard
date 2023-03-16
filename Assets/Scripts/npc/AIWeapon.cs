using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AIWeapon : MonoBehaviour
{
    Gun current_gun;
    GameObject equipted_gun;
    public GameObject character_socket;
    public GameObject weapon_drop;

    public GameObject w_button;
    public GameObject w_image;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void EpuipWeapon(GameObject picked_gun, Gun gun)
    {
        current_gun = gun;
        equipted_gun = picked_gun;
        equipted_gun.transform.SetParent(character_socket.transform, false);
        equipted_gun.GetComponent<weaponPlug>().wepaon_plug.transform.SetParent(character_socket.transform, false);
        weapon_drop = equipted_gun.GetComponent<weaponPlug>().weapon_drop;
    }

    public void ActivateWeapon()
    {
        animator.SetBool("equip", true);
    }

    public bool HasWeapon()
    {
        return equipted_gun != null;
    }

    public void UnparentWeapon()
    {
        GameObject dropped_weapon = Instantiate(weapon_drop, equipted_gun.transform.position, equipted_gun.transform.rotation) as GameObject;

        dropped_weapon.GetComponent<WeaponPickup>().image = w_image;
        dropped_weapon.GetComponent<WeaponPickup>().button = w_button;
        //equipted_gun.transform.SetParent(null);
        //equipted_gun.GetComponentInChildren<Rigidbody>().isKinematic = false;
        Destroy(equipted_gun);
        //equipted_gun=null;
        current_gun = null;
    }
}
