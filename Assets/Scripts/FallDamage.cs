using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    Vector3 init_vel, col_vel;

    public float fall_damage_treshold = 10f, final_vel;

    public Health health;
        

    // Start is called before the first frame update
    void Start()
    {
        if(GetComponent<Health>())
            health = GetComponent<Health>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        init_vel = GetComponent<Rigidbody>().velocity;

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        col_vel = GetComponent<Rigidbody>().velocity;
        final_vel = (col_vel - init_vel).magnitude;

        if (collision.gameObject.GetComponent<EntityHitbox>() && collision.gameObject.GetComponent<EntityHitbox>().enabled && final_vel >= fall_damage_treshold)
            collision.gameObject.GetComponentInParent<EntityHitbox>().OnRaycastHit(CalculateFallDamage(), transform.position, collision.rigidbody);

        else if (collision.gameObject.GetComponent<playerHitbox>() && collision.gameObject.GetComponent<playerHitbox>().enabled && final_vel >= fall_damage_treshold)
            collision.gameObject.GetComponent<playerHitbox>().onRaycastHitPlayer(CalculateFallDamage());

        if (final_vel >= fall_damage_treshold)
        {
            if (health != null)
                health.health -= CalculateFallDamage();
        }
    }

    float CalculateFallDamage()
    {
        return final_vel * .15f * GetComponent<Rigidbody>().mass;
    }
}
