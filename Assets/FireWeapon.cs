using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Animations;
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
    public AudioClip weapon_fire_sound;
    public AudioSource weapon_audio;
    public WeaponRecoil weapon_recoil;
    public GameObject bullet_shape;
    public RuntimeAnimatorController rac;

    List<Bullet> bullets = new List<Bullet>();

    Ray ray;
    RaycastHit hit;

    public Item weapon_stats;

    [Header("")]
    public GameObject muzzle_flash;
    private IEnumerator coroutine;

    public float bullet_speed = 1000f;
    public float bullet_drop = 0f;
    public float max_lifetime = 3f;

    float fire_rate;

    float acculumated_time;

    public bool is_firing;
    public bool can_fire = true;

    // Start is called before the first frame update
    void Start()
    {
        weapon_audio = GetComponentInChildren<AudioSource>();
        weapon_recoil = GetComponentInChildren<WeaponRecoil>();
        if(GetComponentInChildren<Animator>())
            GetComponentInChildren<Animator>().runtimeAnimatorController = rac;

        fire_rate = 60f / weapon_stats.weapon_specs.fire_rate;
        if(weapon_stats.weapon_specs.bullet_type.bullet_shape != null) bullet_shape = weapon_stats.weapon_specs.bullet_type.bullet_shape;
        bullet_speed = weapon_stats.weapon_specs.bullet_type.bullet_velocity;
    }

    Vector3 GetPosition(Bullet bullet)
    {
        Vector3 gravity = Vector3.down * bullet_drop;
        return (bullet.initial_pos) + (bullet.initial_vel * bullet.time) + (0.5f * gravity * bullet.time * bullet.time);
    }

    Bullet CreateBullet(Vector3 position, Vector3 velovity)
    {
        Bullet bullet = new Bullet();
        bullet.initial_pos = position;
        bullet.initial_vel = velovity;
        bullet.time = 0f;
        bullet.tracer = Instantiate(bullet_trail, position, Quaternion.identity);
        bullet.tracer.AddPosition(position);
        return bullet;
    }

    public void StartFiring()
    {
        is_firing = true;
        acculumated_time = 0f;
        for (int i = 0; i < weapon_stats.weapon_specs.number_of_bullets; i++)
            FireBullet();
    }

    public void UpdateWeapon(float delta_time)
    {
        if (is_firing)
            UpdateFiring(delta_time);

        acculumated_time += delta_time;

        UpdateBullets(delta_time);
    }

    public void UpdateFiring(float delta_time)
    {

        

        //  can only fire if acculumated is equal or exceeded fire_rate. if fire_rate is replaced with '0f', causes bug where first shot fired creates 2 bullets but not after
        while (acculumated_time >= fire_rate)
        {
            for (int i=0; i<weapon_stats.weapon_specs.number_of_bullets; i++) 
                FireBullet();
            acculumated_time -= fire_rate;
        }
    }
   
    public void UpdateBullets(float delta_time)
    {
        SimulateBullets(delta_time);
        DestroyBullets();
    }
    
    void SimulateBullets(float delta_time)
    {
        bullets.ForEach(bullet =>
        {
            Vector3 p0 = GetPosition(bullet);
            bullet.time += delta_time;
            Vector3 p1 = GetPosition(bullet);
            RaycastSegment(p0, p1, bullet);

        });
    }

    void DestroyBullets()
    {
        bullets.RemoveAll(bullet => bullet.time > max_lifetime);
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

            if (bullet_shape != null)
            {
                GameObject embed_rebar = Instantiate(bullet_shape, hit.point, transform.rotation) as GameObject;
                embed_rebar.transform.parent = hit.collider.transform;
            }

            //if (hit.collider) print("Hit " + hit.collider.name);      debugging

            if (bullet.tracer != null) bullet.tracer.transform.position = hit.point;
            bullet.time = max_lifetime;

            var entity_hitbox= hit.collider.GetComponent<EntityHitbox>();
            if (entity_hitbox) entity_hitbox.OnRaycastHit(weapon_stats.bullets_specs.bullet_damage, direction, hit.collider.attachedRigidbody);

            
            var ai_agent = hit.collider.GetComponentInParent<AIAgent>();
            if (ai_agent) ai_agent.is_aggressive = true;

            var player_hitbox = hit.collider.GetComponent<playerHitbox>();
            if (player_hitbox) player_hitbox.onRaycastHitPlayer(weapon_stats.bullets_specs.bullet_damage/0.85f);

        }
        else 
        { 
            if (bullet.tracer != null) bullet.tracer.transform.position = end; 
        }
    }
    
    public void FireBullet()
    {

        weapon_audio.clip = weapon_fire_sound;
        weapon_audio.Play();

        //  allows gun to hit object in middle of screen. keep commented out for possible future inclusion
        //Vector3 velocity = (raycast_destination.position - raycast_origin.position).normalized * bullet_speed;

        
        Vector3 velocity;

        if (!weapon_recoil.enabled)
        {
            Vector3 v = (raycast_origin.forward + new Vector3(Random.Range(-.1f, .1f), Random.Range(-.1f, .1f), Random.Range(-.1f, .1f))) * bullet_speed;
            velocity = v;
        }
        else
        {
            float w_x = weapon_stats.weapon_specs.bullet_spread.x;
            float w_y = weapon_stats.weapon_specs.bullet_spread.y;
            float w_z = weapon_stats.weapon_specs.bullet_spread.z;


            Vector3 v = (raycast_origin.forward + new Vector3(Random.Range(-w_x, w_x), Random.Range(-w_y, w_y), Random.Range(-w_z, w_z))).normalized * bullet_speed;
            velocity = v;
        }        

        //Vector3 velocity = raycast_origin.forward.normalized * bullet_speed;
        
        var bullet = CreateBullet(raycast_origin.position, velocity);
        bullets.Add(bullet);

        
        if (!weapon_recoil.enabled) return;

        weapon_recoil.Recoil();
    }

    public void StopFiring()
    {
        is_firing = false;
    }

    public void NewAnimEvent(string event_name)
    {
        print(event_name);
    }
}
