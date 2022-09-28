using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject bullet_prefab;
    public Transform barrel;

    public AudioClip shot;
    

    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bullet_prefab, barrel.transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(barrel.transform.forward * speed, ForceMode.Impulse);

            AudioSource audioSource = Camera.main.GetComponent<AudioSource>();

            audioSource.clip = shot;
            audioSource.Play();

            Destroy(bullet, 3f);
        }
    }
}
