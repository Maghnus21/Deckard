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

    public AIWeaponIK weapon_ik;
    public MeshSocket mesh_socket;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        weapon_ik = GetComponent<AIWeaponIK>();
        mesh_socket = GetComponentInChildren<MeshSocket>();
    }


    public void EpuipWeapon(GameObject picked_gun, Gun gun)
    {
        current_gun = gun;
        equipted_gun = picked_gun;

        mesh_socket.Attach(equipted_gun.transform);
        /*
        equipted_gun.transform.SetParent(character_socket.transform, false);
        equipted_gun.GetComponent<weaponPlug>().wepaon_plug.transform.SetParent(character_socket.transform, false);
        */
        weapon_drop = equipted_gun.GetComponent<weaponPlug>().weapon_drop;
    }

    public void ActivateWeapon()
    {

        StartCoroutine(EquipWeaponIK());
    }

    
    IEnumerator EquipWeaponIK()
    {
        animator.SetBool("equip", true);
        yield return new WaitForSeconds(.5f);

        while(animator.GetCurrentAnimatorStateInfo(1).normalizedTime < 1f)
        {
            yield return null;
        }

        //weapon_ik.SetAimTransform(GetComponent<AIAgent>().player_transform);
        weapon_ik.enabled = true;
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

    public void SetTarget(Transform target)
    {
        weapon_ik.SetTargetTransform(target);
    }
}
