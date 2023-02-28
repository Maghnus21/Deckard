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
}
