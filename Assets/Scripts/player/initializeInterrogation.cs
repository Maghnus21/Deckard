using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class initializeInterrogation : MonoBehaviour
{
    public Image can_pickup;

    RaycastHit hit;
    Ray ray;

    float ray_length = 5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, ray_length) && hit.collider.gameObject.CompareTag("Suspect"))
        {
            this.gameObject.GetComponent<InspectBoxItem>().enabled = false;
            can_pickup.enabled = true;

            if (Input.GetKeyDown(KeyCode.F))
            {
                hit.collider.gameObject.GetComponentInParent<SusDialogue>().enabled = true;
                hit.collider.gameObject.GetComponentInParent<SusDialogue>().kit.SetActive(true);
            }
            
        }
        else
        {
            this.gameObject.GetComponent<InspectBoxItem>().enabled = true;
        }
    }
}
