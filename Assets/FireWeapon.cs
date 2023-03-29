using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class FireWeapon : MonoBehaviour
{
    public Item weapon_stats;

    [Header("Transforms for recoil and aiming")]
    public Transform anchor;
    public Transform recoil_point;
    public Transform ads_state;
    public Transform hip_state;

    [Header("")]
    public GameObject muzzle_flash;
    private IEnumerator coroutine;

    public Transform player_chest;
    public Transform main_camera;

    //  vector3 variables for recoil
    Vector3 rotationalRecoil;
    Vector3 Rot;


    public float hip_recoil_mod = 1f;
    public float ads_recoil_mod = 2f;
    float recoil_mod = 1f;


    // Start is called before the first frame update
    void Start()
    {
        main_camera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        rotationalRecoil = Vector3.Lerp(rotationalRecoil, Vector3.zero, weapon_stats.recoilRotationReturn * Time.deltaTime);
        Rot = Vector3.Slerp(Rot, rotationalRecoil, weapon_stats.recoilRotationSpeed * Time.deltaTime);

        
        recoil_point.localRotation = Quaternion.Euler(Rot / recoil_mod);
        
   
        //recoilPoint.localRotation = Quaternion.Euler(Rot);

        //main_camera.localRotation = Quaternion.Euler(Rot / 3);
        player_chest.localRotation = Quaternion.Euler(Rot / 3);

        if (Input.GetMouseButton(1)) Aim(true);
        else Aim(false);
    }

    void Aim(bool is_aiming)
    {
        //  anchor linearly interpolates between ads and hip position if is_aiming is true
        if (is_aiming)
        {
            anchor.position = Vector3.Lerp(anchor.position, ads_state.position, Time.deltaTime * weapon_stats.ads_speed);
            Camera.main.fieldOfView = 30f;
            recoil_mod = ads_recoil_mod;
        }
        else
        {
            anchor.position = Vector3.Lerp(anchor.position, hip_state.position, Time.deltaTime * weapon_stats.ads_speed);
            Camera.main.fieldOfView = 65f;
            recoil_mod = hip_recoil_mod;
        }
    }

    public void FireGun()
    {

    }

    public void FireGun(Vector3 recoil)
    {

    }

    void Recoil()
    {

    }

    void UpdateAmmo()
    {

    }

    void DsiplayAmmo()
    {

    }



    IEnumerator MuzzleFlash(float seconds)
    {
        yield return null;
    }
}
