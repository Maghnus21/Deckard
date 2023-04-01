using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AIWeapon : MonoBehaviour
{
    public Item current_gun;
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

    public ParticleSystem hit_effect;

    float fire_rate;
    float next_round = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();
        head_tracking = GetComponent<AIHeadBone>();
        weapon_ik = GetComponent<AIWeaponIK>();
        mesh_socket = GetComponentInChildren<MeshSocket>();

    }


    public void EquiptWeapon(GameObject picked_gun, Item gun)
    {
        current_gun = gun;
        equipted_gun = picked_gun;

        equipted_gun.GetComponent<FireWeapon>().hit_effect = hit_effect;
        equipted_gun.GetComponent<WeaponRecoil>().enabled = false;

        mesh_socket.Attach(equipted_gun.transform);
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
        Destroy(equipted_gun);

        current_gun = null;
        
    }

    public void SetTarget(Transform target)
    {
        weapon_ik.SetTargetTransform(target);
    }

    public void FireWeapon()
    {
        print("bullet spawn " + equipted_gun.transform.position + "\tAgent transform" + transform.position);

        equipted_gun.GetComponent<FireWeapon>().FireBullet();
    }
}
