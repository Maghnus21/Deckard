using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorStop : MonoBehaviour
{
    public Health health;

    public doorLogic door_logic;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        if (door_logic != null)
            door_logic.is_locked = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(health.health <=0f)
            door_logic.is_locked=false;
    }
}
