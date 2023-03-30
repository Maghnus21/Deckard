using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class FireWeapon : MonoBehaviour
{

    class Bullet
    {
        public float time;
        public Vector3 initial_pos;
        public Vector3 initial_vel;
        public TrailRenderer tracer;
    }

    public Transform raycast_origin;
    public Transform raycast_destination;
    public ParticleSystem hit_effect;
    public TrailRenderer bullet_trail;

    List<Bullet> bullets = new List<Bullet>();

    Ray ray;
    RaycastHit hit;

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

    public float bullet_speed = 1000f;
    public float bullet_drop = 0f;
    public float max_lifetime = 3f;


    public float hip_recoil_mod = 1f;
    public float ads_recoil_mod = 2f;
    float recoil_mod = 1f;

    float fire_rate;

    float acculumated_time;

    bool is_ads = false;

    public bool is_firing;

    // Start is called before the first frame update
    void Start()
    {
        main_camera = Camera.main.transform;

        fire_rate = 60f / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        rotationalRecoil = Vector3.Lerp(rotationalRecoil, Vector3.zero, weapon_stats.recoilRotationReturn * Time.deltaTime);
        Rot = Vector3.Slerp(Rot, rotationalRecoil, weapon_stats.recoilRotationSpeed * Time.deltaTime);

        
        recoil_point.localRotation = Quaternion.Euler(Rot / recoil_mod);

        //main_camera.localRotation = Quaternion.Euler(Rot / 3);
        player_chest.localRotation = Quaternion.Euler(Rot / 3);
        */
        
    }

    public void StartFiring()
    {
        is_firing = true;
        acculumated_time = 0f;
        FireBullet();
    }

    public void StopFiring()
    {
        is_firing = false;
    }
    
    /*
    Vector3 GetPosition(Bullet bullet)
    {
        Vector3 gravity = Vector3.down * bullet_drop;
        return (bullet.initial_pos) + (bullet.initial_vel * bullet.time) + (0.5f * gravity * bullet.time * bullet.time);
    }

    Bullet CreateBullet(Vector3 position, Vector3 velocity)
    {
        Bullet bullet = new Bullet();
        bullet.initial_pos = position;
        bullet.initial_vel = velocity;
        bullet.time = 0f;
        bullet.tracer = Instantiate(bullet_trail, position, Quaternion.identity);
        bullet.tracer.AddPosition(position);
        return bullet;
    }

    public void UpdateBullets(float delta_time)
    {
        SimulateBullets(delta_time);
        DestroyBullets();
    }

    void SimulateBullets(float delta_time)
    {
        foreach(Bullet bullet in bullets)
        {
            Vector3 p0 = GetPosition(bullet);
            bullet.time += delta_time;
            Vector3 p1 = GetPosition(bullet);
            RaycastSegment(p0, p1, bullet);
        }
    }

    void DestroyBullets()
    {
        foreach(Bullet bullet in bullets)
        {
            if(bullet.time >= max_lifetime)
            {
                bullets.Remove(bullet);
            }
        }
    }
    
    
    void RaycastSegment(Vector3 start, Vector3 end, Bullet bullet)
    {
        Vector3 direction = end - start;
        float distance = direction.magnitude;

        ray.origin = start;
        ray.direction = end - start;

        if (Physics.Raycast(ray, out hit, distance))
        {
            //Debug.DrawLine(ray.origin, hit.point, Color.red, 1f);

            hit_effect.transform.position = hit.point;
            hit_effect.transform.forward = hit.normal;
            hit_effect.Emit(1);

            bullet.tracer.transform.position = hit.point;
            bullet.time = max_lifetime;
        }
        else bullet.tracer.transform.position = end;
    }
    
    
    public void UpdateFiring(float delta_time)
    {
        acculumated_time += delta_time;

        while (acculumated_time >= 0f)
        {
            FireBullet();

            acculumated_time -= fire_rate;
        }
    }
    */
    /*public void Aim(bool is_aiming)
    {
        //  anchor linearly interpolates between ads and hip position if is_aiming is true
        if (is_aiming)
        {
            anchor.position = Vector3.Lerp(anchor.position, ads_state.position, Time.deltaTime * weapon_stats.ads_speed);
            Camera.main.fieldOfView = 30f;
            recoil_mod = ads_recoil_mod;
            is_ads = true;
        }
        else
        {
            anchor.position = Vector3.Lerp(anchor.position, hip_state.position, Time.deltaTime * weapon_stats.ads_speed);
            Camera.main.fieldOfView = 65f;
            recoil_mod = hip_recoil_mod;
            is_ads = false;
        }
    }
    */

    public void FireBullet()
    {
        /*
        Vector3 velocity;

        if (is_ads) velocity = (raycast_destination.position - raycast_origin.position).normalized * bullet_speed;
        else velocity = raycast_origin.forward.normalized * bullet_speed;

        var bullet = CreateBullet(raycast_origin.position, velocity);
        bullets.Add(bullet);
        */

        
        ray.origin = raycast_origin.position;

        if(is_ads)  ray.direction = raycast_destination.position - raycast_origin.position;
        else ray.direction = raycast_origin.forward;

        var tracer = Instantiate(bullet_trail, ray.origin, Quaternion.identity);
        tracer.AddPosition(ray.origin);

        if(Physics.Raycast(ray, out hit))
        {
            //Debug.DrawLine(ray.origin, hit.point, Color.red, 1f);

            hit_effect.transform.position = hit.point;
            hit_effect.transform.forward = hit.normal;
            hit_effect.Emit(1);

            tracer.transform.position = hit.point;
        }
        

        //Recoil();
    }

    /*
    void Recoil()
    {
        Mathf.Clamp(rotationalRecoil.x, -90f, 90f);
        rotationalRecoil += new Vector3(-weapon_stats.recoilRotation.x, Random.Range(-weapon_stats.recoilRotation.y, weapon_stats.recoilRotation.y), Random.Range(-weapon_stats.recoilRotation.z, weapon_stats.recoilRotation.z));
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
    */




}
