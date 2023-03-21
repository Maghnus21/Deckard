using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AIWeapon : MonoBehaviour
{
    public Gun current_gun;
    public GameObject equipted_gun;
    public GameObject character_socket;
    public GameObject weapon_drop;

    public GameObject w_button;
    public GameObject w_image;

    public AIWeaponIK weapon_ik;
    public MeshSocket mesh_socket;

    public GameObject fire_point;

    Animator animator;
    public AIHeadBone head_tracking;

    float fire_rate;
    float next_round = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();
        head_tracking = GetComponent<AIHeadBone>();
        weapon_ik = GetComponent<AIWeaponIK>();
        mesh_socket = GetComponentInChildren<MeshSocket>();

    }


    public void EquiptWeapon(GameObject picked_gun, Gun gun)
    {
        current_gun = gun;
        equipted_gun = picked_gun;

        mesh_socket.Attach(equipted_gun.transform);

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

        weapon_ik.enabled = true;
        head_tracking.enabled = true;
    }
    

    public bool HasWeapon()
    {
        return equipted_gun != null;
    }

    public void UnparentWeapon()
    {
        GameObject dropped_weapon = Instantiate(weapon_drop, equipted_gun.transform.position, equipted_gun.transform.rotation) as GameObject;

        Destroy(equipted_gun);

        current_gun = null;
        
    }

    public void SetTarget(Transform target)
    {
        weapon_ik.SetTargetTransform(target);
    }

    public void FireWeapon()
    {
        GameObject bullet = Instantiate(current_gun.bullet, equipted_gun.transform.position, equipted_gun.transform.rotation) as GameObject;
        print("bullet spawn " + equipted_gun.transform.position + "\tAgent transform" + transform.position);
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * .3f);
    }
}
