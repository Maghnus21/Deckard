using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterrogationInteraction : MonoBehaviour
{
    public GameObject voight_kampff;
    public GameObject suspect;
    public Camera interrogate_cam;

    RaycastHit hit;
    Ray ray;

    int ray_length = 5;


    // Start is called before the first frame update
    void Start()
    {
        interrogate_cam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward * ray_length, out hit) && hit.collider.gameObject.tag == "suspect")
        {
            Debug.Log("looking");

            if (Input.GetKey(KeyCode.F))
            {
                Debug.Log("interrogated suspect");
            }
        }
    }
}
