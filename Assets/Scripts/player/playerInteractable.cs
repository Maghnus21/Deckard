using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteractable : MonoBehaviour
{
    RaycastHit hit;
    Ray ray;
    float ray_length = 3f;


    public bool looking_at_interactable = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * ray_length, Color.red);
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, ray_length) && hit.collider.CompareTag("Interactable"))
        {
            looking_at_interactable = true;
        }
        else
        {
            looking_at_interactable = false;
        }
    }
}
