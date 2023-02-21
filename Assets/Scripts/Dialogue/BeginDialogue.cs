using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginDialogue : MonoBehaviour
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
        ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);


        if (Physics.Raycast(ray, out hit, 5f) && hit.collider.gameObject.GetComponentInParent<BranchDialogueTest>())
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                hit.collider.GetComponentInParent<BranchDialogueTest>().enabled = true;
                hit.collider.GetComponentInParent<BranchDialogueTest>().showDialogue();
            }
        }
    }
}
