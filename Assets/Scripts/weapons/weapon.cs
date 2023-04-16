using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.VFX;

public class weapon : MonoBehaviour
{
    public Item[] loadout = new Item[9];
    public Item equipted_gun = null;
    public Transform weaponPosition;
    public AudioClip weapon_fire_sound;
    public AudioSource weaponSource;

    public TextMeshProUGUI ammo_count_text;

    [Header("Recoil gameobject reference")]
    public Transform recoilPoint;

    //  vector3 variables for recoil
    Vector3 rotationalRecoil;
    Vector3 Rot;

    public Transform main_camera;
    public Transform player_chest;

    // gun fire rate variables
    float fireRate;
    float nextRound;
    float rounds_fired = 0;


    private int currentIndex;
    GameObject currentWeapon = null;

    private IEnumerator coroutine;

    public ScriptableObject equipted_so;
    GameObject t_newWeapon;

    public ParticleSystem bullet_impact_effect;
    public Transform bullet_raycast_destination;

    public BulletBehaviour bulletBehaviour;

    void Awake()
    {
        
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        //  NEED TO IMPROVE SYSTEM TO ALLOW PLAYER TO PICK SLOT FOR ITEM
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Equip(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Equip(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Equip(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Equip(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Equip(4);
        }


        // getMouseButton(1) means right mouse button, 0 is left
        if (currentWeapon != null && !loadout[currentIndex].is_melee_weapon && !loadout[currentIndex].is_throwable)
        {
            Aim(Input.GetMouseButton(1));

            // 60 seconds divided by fire_rate from Gun scriptableObject
            //fireRate = 60f / loadout[currentIndex].fire_rate;

            /*
            if (rounds_fired < loadout[currentIndex].magazine_size)
            {
                if (Input.GetMouseButton(0) && Time.time > nextRound)
                {
                    nextRound = Time.time + fireRate;
                    FireWeapon();
                    rounds_fired++;

                    DisplayAmmoCount();
                }
            }
            */
            if (rounds_fired > 0 && Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("GUN RELOADED");

                UpdateAmmoCount();
            }
            else if (rounds_fired == 20 && Input.GetMouseButtonDown(0))
            {
                Debug.Log("GUN EMPTY PRESS R TO RELOAD");
            }

            recoilPoint = currentWeapon.transform.Find("anchor/recoil");

            //rotationalRecoil = Vector3.Lerp(rotationalRecoil, Vector3.zero, loadout[currentIndex].recoilRotationReturn * Time.deltaTime);

            //Rot = Vector3.Slerp(Rot, rotationalRecoil, loadout[currentIndex].recoilRotationSpeed * Time.deltaTime);


            if (Input.GetMouseButton(1))
            {
                recoilPoint.localRotation = Quaternion.Euler(Rot / 1.5f);
            }
            else
            {
                recoilPoint.localRotation = Quaternion.Euler(Rot);
            }
            //recoilPoint.localRotation = Quaternion.Euler(Rot);

            main_camera.localRotation = Quaternion.Euler(Rot / 3);
            player_chest.localRotation = Quaternion.Euler(Rot / 3);
        }

        if (currentWeapon != null && loadout[currentIndex].is_melee_weapon)
        {

            if (Input.GetMouseButtonDown(0))
            {
                print("SWUNG WEAPON " + loadout[currentIndex].name);

                Ray ray;
                RaycastHit hit;
                float damage = 30f;

                ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward * 5f);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null && hit.collider.CompareTag("Suspect") || hit.collider.CompareTag("NPC"))
                    {
                        hit.collider.GetComponent<EntityHitbox>().OnRaycastHit(damage, ray.direction, hit.rigidbody);
                        print("HIT ENEMY " + hit.collider.name);
                    }
                    else
                    {
                        print("MISS");
                    }
                }
                
            }
        }

        if (currentWeapon != null && loadout[currentIndex].is_throwable)
        {

        }

        else { };





        //  works but need to reduce movement on x axis as too disorientating
        if(currentWeapon != null && Input.GetKeyDown(KeyCode.B))
        {
            Destroy(currentWeapon);
            currentWeapon = null;
        }


        if (bulletBehaviour != null)
        {
            bulletBehaviour.UpdateBullets(Time.deltaTime);
        }
    }

    public void Equip(int p_int)
    {
        if (currentWeapon != null) Destroy(currentWeapon);

        currentIndex = p_int;
        

        if (!loadout[currentIndex].is_melee_weapon && !loadout[currentIndex].is_throwable)
        {
            t_newWeapon = Instantiate(loadout[p_int].item_prefab, weaponPosition.position, weaponPosition.rotation, weaponPosition) as GameObject;
        }
        else if(loadout[currentIndex].is_melee_weapon)
        {
            t_newWeapon = Instantiate(loadout[p_int].weapon_prefab, weaponPosition.position, weaponPosition.rotation, weaponPosition) as GameObject;
        }
        else if (loadout[currentIndex].is_throwable)
        {
            t_newWeapon = Instantiate(loadout[p_int].weapon_prefab, weaponPosition.position, weaponPosition.rotation, weaponPosition) as GameObject;
        }


        //GameObject t_newWeapon = Instantiate(loadout[p_int].gun_prefab, weaponPosition.position, weaponPosition.rotation, weaponPosition) as GameObject;
        t_newWeapon.transform.localPosition = Vector3.zero;
        t_newWeapon.transform.localEulerAngles = Vector3.zero;

        currentWeapon = t_newWeapon;

        if (!loadout[currentIndex].is_melee_weapon)
        {
            weapon_fire_sound = loadout[currentIndex].gun_fire;
            weaponSource.clip = weapon_fire_sound;
        }
        
        equipted_gun = loadout[currentIndex];

        if (t_newWeapon.GetComponentInChildren<BulletBehaviour>())
        {
            bulletBehaviour = t_newWeapon.GetComponentInChildren<BulletBehaviour>();

            bulletBehaviour.bullet_impact_effect = bullet_impact_effect;
            bulletBehaviour.raycast_destination = bullet_raycast_destination;
        }
        else
        {
            bulletBehaviour = null;
        }
    }

    void Aim(bool is_aiming)
    {

        //  transform references to empty gameObjects
        Transform anchor = currentWeapon.transform.Find("anchor");
        Transform ads_state = currentWeapon.transform.Find("states/ads");
        Transform hip_state = currentWeapon.transform.Find("states/hip");

        //  anchor linearly interpolates between ads and hip position if is_aiming is true
        if (is_aiming)
        {
            anchor.position = Vector3.Lerp(anchor.position, ads_state.position, Time.deltaTime * loadout[currentIndex].ads_speed);
            Camera.main.fieldOfView = 30f;
        }
        else
        {
            anchor.position = Vector3.Lerp(anchor.position, hip_state.position, Time.deltaTime * loadout[currentIndex].ads_speed);
            Camera.main.fieldOfView = 65f;
        }
    }

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

    
    void Recoil()
    {
        Mathf.Clamp(rotationalRecoil.x, -90f, 90f);
        //rotationalRecoil += new Vector3(-loadout[currentIndex].recoilRotation.x, Random.Range(-loadout[currentIndex].recoilRotation.y, loadout[currentIndex].recoilRotation.y), Random.Range(-loadout[currentIndex].recoilRotation.z, loadout[currentIndex].recoilRotation.z));
    }

    void UpdateAmmoCount()
    {
        loadout[currentIndex].ammo_reserve -= rounds_fired;

        rounds_fired = 0;

        DisplayAmmoCount();
    }

    public void DisplayAmmoCount()
    {
        //ammo_count_text.text = (loadout[currentIndex].magazine_size - rounds_fired + "/" + loadout[currentIndex].magazine_size + "\nAmmo Reserve - " + loadout[currentIndex].ammo_reserve).ToString();
    }

    IEnumerator MuzzleFlash(float seconds)
    {
        GameObject.Find("anchor/recoil/model/resources/muzzle_flash_spwn").SetActive(true);

        yield return new WaitForSeconds(seconds);

        GameObject.Find("anchor/recoil/model/resources/muzzle_flash_spwn").SetActive(false);
    }
}
