using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{
    public FireWeapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        weapon = GetComponentInParent<FireWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReloadFinished(string event_name)
    {
        if(event_name == "ready")
        {
            weapon.ReloadWeapon();
        }
    }
}
