using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using UnityEngine;

/// <summary>
/// ISSUES:
/// (SEMI_FIXED) force not applied to rigidbody when shot. link to tutorial for possible help: https://www.youtube.com/watch?v=zjuI5Jdzjxo
/// force applied to rigidbody in objects but not on enemy ragdolls, go investigate
/// </summary>



public class BulletBehaviour : MonoBehaviour
{
    class Bullet
    {
        public float time;
        public Vector3 initial_pos;
        public Vector3 initial_vel;
        //public TrailRenderer trail;
    }



    public AIAgent agent;

    public GameObject bulllet_impact;
    public ParticleSystem bullet_impact_effect;
    public TrailRenderer bullet_tracer;
    public float damage = 20f;
    public float bullet_speed = 1000;
    public float bullet_drop = 0f;

    public bool debug_collision_cube = false;

    public Transform raycast_destination;

    float max_lifetime = 3f;

    RaycastHit hit;
    Ray ray;
    float range = 8f;

    float maxtime = 2f;
    float time = 2;


    List<Bullet> bullets = new List<Bullet>();


    void Start()
    {
        time = maxtime;
        //  this is to prevent raycast from gun sight hitting bullet and sending world location data to change bullet spawn rotation
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    }

    public void UpdateBullets(float delta_time)
    {
        SimulateBullets(delta_time);
        DestroyBullet();
    }

    void DestroyBullet()
    {
        foreach(Bullet bullet in bullets)
        {
            if(bullet.time >= max_lifetime)
            {
                bullets.Remove(bullet);
            }
        }
    }

    void SimulateBullets(float delta_time)
    {
        foreach(Bullet b in bullets)
        {
            Vector3 p0 = GetPosition(b);
            b.time += delta_time;
            Vector3 p1 = GetPosition(b);
            RaycastSegment(p0, p1, b);
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
            if (debug_collision_cube) { Instantiate(bulllet_impact, hit.point, Quaternion.identity); }

            bullet_impact_effect.transform.position = hit.point;
            bullet_impact_effect.transform.forward = hit.normal;
            bullet_impact_effect.Emit(1);

            //bullet.trail.transform.position = hit.point;
        }
    }

    public void FireBullet()
    {
        Vector3 velocity = (raycast_destination.position - transform.position).normalized * bullet_speed;
        Bullet bullet = CreateBullet(transform.position, velocity);
        bullets.Add(bullet);
    }

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
        //bullet.trail = Instantiate(bullet_tracer, position, Quaternion.identity);
        //bullet.trail.AddPosition(position);
        return bullet;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + transform.forward);
    }
}
