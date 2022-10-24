using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
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
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, ray_length) && hit.collider.gameObject.CompareTag("Suspect") && Input.GetButtonDown("Fire1"))
        {
            hit.collider.gameObject.GetComponent<SusDialogue>().enabled = true;
            hit.collider.gameObject.GetComponent<SusDialogue>().kit.SetActive(true);
        }
    }
}
