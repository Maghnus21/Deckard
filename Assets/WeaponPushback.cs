using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPushback : MonoBehaviour
{
    Rigidbody player_rb;

    // Start is called before the first frame update
    void Start()
    {
        player_rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pushback()
    {
        player_rb.AddForce(-Camera.main.transform.forward * 1f, ForceMode.VelocityChange);
    }
}
