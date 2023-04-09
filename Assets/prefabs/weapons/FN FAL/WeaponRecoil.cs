using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRecoil : MonoBehaviour
{

    public Item weapon_stats;

    [Header("Transforms for recoil and aiming")]
    public Transform anchor;
    public Transform recoil_point;
    public Transform ads_state;
    public Transform hip_state;

    [Header("")]
    public Transform player_chest;
    public Transform main_camera;

    //  vector3 variables for recoil
    Vector3 rotationalRecoil;
    Vector3 Rot;

    public Vector3 recoil_rotation = new Vector3(5, 4, 6);
    public int recoil_speed = 40, recoil_return=3;

    public int ads_speed = 5;
    public float hip_recoil_mod = 1f;
    public float ads_recoil_mod = 3f;
    float recoil_mod = 1f;

    bool is_ads = false;

    // Start is called before the first frame update
    void Start()
    {
        weapon_stats = GetComponent<FireWeapon>().weapon_stats;
        Rot.x = Mathf.Clamp(Rot.x, -90f, 90f);

        recoil_rotation = weapon_stats.weapon_specs.recoil_rotation;
        recoil_speed = weapon_stats.weapon_specs.recoil_speed;
        recoil_return = weapon_stats.weapon_specs.recoil_return;
    }

    // Update is called once per frame
    void Update()
    {
        rotationalRecoil = Vector3.Lerp(rotationalRecoil, Vector3.zero, recoil_return * Time.deltaTime);

        Rot = Vector3.Slerp(Rot, rotationalRecoil, recoil_speed * Time.deltaTime);

        recoil_point.localRotation = Quaternion.Euler(Rot);
        if(main_camera != null) main_camera.localRotation = Quaternion.Euler(new Vector3(Rot.x / 2f, 0f, 0f));
        //if(player_chest != null) player_chest.localRotation = Quaternion.Euler(new Vector3(Rot.x / 2, 0f, 0f));
    }

    public void Aim(bool is_aiming)
    {
        //  anchor linearly interpolates between ads and hip position if is_aiming is true
        if (is_aiming)
        {
            anchor.position = Vector3.Lerp(anchor.position, ads_state.position, Time.deltaTime * ads_speed);
            Camera.main.fieldOfView = 30f;
            recoil_mod = ads_recoil_mod;
        }
        else
        {
            anchor.position = Vector3.Lerp(anchor.position, hip_state.position, Time.deltaTime * ads_speed);
            Camera.main.fieldOfView = 65f;
            recoil_mod = hip_recoil_mod;
        }
    }

    /*
    void FireWeapon()
    {
        Transform anchor = currentWeapon.transform.Find("anchor");
        Transform sight_look = currentWeapon.transform.Find("anchor/recoil/model/resources/sight_point");

        Transform bullet_spawn = currentWeapon.transform.Find("anchor/recoil/model/resources/bullet_point");

        // variables for muzzle flash time and random rotation to be applied to muzzle flash
        Vector3 randomRot = new Vector3(0f, 0f, Random.Range(-45f, 45f));



        bulletBehaviour.FireBullet();

        weaponSource.Play();

        // starts coroutine MuzzleFlash and uses flash_time to delay deactivation of muzzle_flash_spwn in game 
        this.StartCoroutine(MuzzleFlash(.05f));
        //  converting randomRot to quarernion angles and applying to muzzle_flash_spwn
        GameObject.Find("anchor/recoil/model/resources/muzzle_flash_spwn").gameObject.transform.localRotation = Quaternion.Euler(randomRot);

        Recoil();
    }
    */

    public void Recoil()
    {
        Mathf.Clamp(rotationalRecoil.x, -90f, 90f);
        rotationalRecoil += new Vector3(-recoil_rotation.x, Random.Range(-recoil_rotation.y, recoil_rotation.y), Random.Range(-recoil_rotation.z, recoil_rotation.z)) / recoil_mod;
    }

}
