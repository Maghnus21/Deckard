using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginDialogue : MonoBehaviour
{
    public GameObject npc_talking;
    public branchDialogueManager branch_dialogue_manager;

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


        if (Physics.Raycast(ray, out hit, 5f) && hit.collider.gameObject.GetComponentInParent<BranchDialogueConvo>())
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                

                npc_talking = hit.collider.GetComponentInParent<BranchDialogueTest>().gameObject;

                branch_dialogue_manager.talking_npc = npc_talking;

                branch_dialogue_manager.showDialogue();
            }
        }
    }
}
