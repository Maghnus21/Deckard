using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{
    public FireWeapon weapon;
    public PlayerGun player_gun;

    // Start is called before the first frame update
    void Start()
    {
        weapon = GetComponentInParent<FireWeapon>();
        player_gun = GetComponentInParent<PlayerGun>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReloadFinished(string event_name)
    {
        if(event_name == "ready")
        {
            player_gun.can_ads = true;

            weapon.ReloadWeapon();
        }
    }
}
