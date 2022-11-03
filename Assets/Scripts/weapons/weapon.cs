using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.VFX;

public class weapon : MonoBehaviour
{
    public Gun[] loadout;
    public Transform weaponPosition;

    [Header("Recoil gameobject reference")]
    public Transform recoilPoint;


    Vector3 rotationalRecoil;
    Vector3 Rot;

    private int currentIndex;
    GameObject currentWeapon = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Equip(0);
        }

        // getMouseButton(1) means right mouse button, 0 is left
        if(currentWeapon != null)
        {
            Aim(Input.GetMouseButton(1));

            if (Input.GetMouseButtonDown(0))
            {
                FireWeapon();
            }

            recoilPoint = currentWeapon.transform.Find("anchor/recoil");

            rotationalRecoil = Vector3.Lerp(rotationalRecoil, Vector3.zero, loadout[currentIndex].recoilRotationReturn * Time.deltaTime);
            
            Rot = Vector3.Slerp(Rot, rotationalRecoil, loadout[currentIndex].recoilRotationSpeed * Time.deltaTime);
            recoilPoint.localRotation = Quaternion.Euler(Rot);

        }

        
        
        
    }

    void Equip(int p_int)
    {
        if (currentWeapon != null) Destroy(currentWeapon);

        currentIndex = p_int;

        GameObject t_newWeapon = Instantiate(loadout[p_int].gun_prefab, weaponPosition.position, weaponPosition.rotation, weaponPosition) as GameObject;
        t_newWeapon.transform.localPosition = Vector3.zero;
        t_newWeapon.transform.localEulerAngles = Vector3.zero;

        currentWeapon = t_newWeapon;
    }

    void Aim(bool is_aiming)
    {
        Transform anchor = currentWeapon.transform.Find("anchor");
        Transform ads_state = currentWeapon.transform.Find("states/ads");
        Transform hip_state = currentWeapon.transform.Find("states/hip");

        if (is_aiming)
        {
            anchor.position = Vector3.Lerp(anchor.position, ads_state.position, Time.deltaTime * loadout[currentIndex].ads_speed);
        }
        else
        {
            anchor.position = Vector3.Lerp(anchor.position, hip_state.position, Time.deltaTime * loadout[currentIndex].ads_speed);
        }
    }

    void FireWeapon()
    {
        RaycastHit hit;

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            Transform bullet_spawn = currentWeapon.transform.Find("anchor/recoil/model/resources/bullet_spawn");

            bullet_spawn.LookAt(hit.point);

            GameObject fired_bullet = Instantiate(loadout[currentIndex].bullet, bullet_spawn.transform.position, bullet_spawn.transform.rotation);
            fired_bullet.GetComponent<Rigidbody>().AddForce(bullet_spawn.transform.forward * loadout[currentIndex].bullet_speed, ForceMode.Impulse);
        }

        Recoil();
    }

    void Recoil()
    {
        rotationalRecoil += new Vector3(-loadout[currentIndex].recoilRotation.x, Random.Range(-loadout[currentIndex].recoilRotation.y, loadout[currentIndex].recoilRotation.y), Random.Range(-loadout[currentIndex].recoilRotation.z, loadout[currentIndex].recoilRotation.z));
    }
}
