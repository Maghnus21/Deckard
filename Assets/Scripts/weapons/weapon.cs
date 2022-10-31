using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Gun[] loadout;
    public Transform weaponPosition;

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
    }

    void Equip(int p_int)
    {
        if (currentWeapon != null) Destroy(currentWeapon);

        GameObject t_newWeapon = Instantiate(loadout[p_int].gun_prefab, weaponPosition.position, weaponPosition.rotation, weaponPosition) as GameObject;
        t_newWeapon.transform.localPosition = Vector3.zero;
        t_newWeapon.transform.localEulerAngles = Vector3.zero;

        currentWeapon = t_newWeapon;
    }
}
