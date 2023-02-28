using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHitbox : MonoBehaviour
{
    public playerHealth player_health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void onRaycastHitPlayer(float damage)
    {
        player_health.playerReceiveDamage(damage);
    }

    public void explodeHitPlayer(float exp_damage, float exp_force, float exp_radius, float exp_up, Vector3 exp_pos)
    {
        player_health.playerReceiveDamage(exp_damage, exp_force, exp_radius, exp_up, exp_pos);
    }
}
