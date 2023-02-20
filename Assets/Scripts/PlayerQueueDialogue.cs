using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQueueDialogue : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward * 5f);

        if (Physics.Raycast(ray, out hit))
        {
            if(Input.GetKeyDown(KeyCode.F) && hit.collider.GetComponentInParent<QueueDialogue>())
            {
                hit.collider.GetComponentInParent<QueueDialogue>().TriggerQueueDialogue();
                print("STARTED DIALOGUE");
            }
        }
    }
}
