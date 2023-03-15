using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWeapon : MonoBehaviour
{
    Gun current_gun;
    GameObject equipted_gun;
    public GameObject character_socket;

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
    }

    public void ActivateWeapon()
    {
        animator.SetBool("equip", true);
    }

    public bool HasWeapon()
    {
        return equipted_gun != null;
    }
}
