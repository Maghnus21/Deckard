using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadeThrow : MonoBehaviour
{
    public GameObject grenade;

    public float delay_time = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            throwGrenade();
        }
    }


    public void throwGrenade()
    {
        GameObject grenade_clone = Instantiate(grenade, Camera.main.transform.position, Camera.main.transform.rotation);
        grenade_clone.GetComponent<Rigidbody>().AddForce(transform.forward * 10f, ForceMode.Impulse);

        grenade_clone.GetComponent<explode>().Invoke("Explode", delay_time);
    }
}
