using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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


        if (Physics.Raycast(ray, out hit, 5f))
        {
            if (Input.GetKeyDown(KeyCode.F) && hit.collider.gameObject.GetComponentInParent<AIAgent>().dialogue_tree != null)
            {
                

                npc_talking = hit.collider.GetComponentInParent<NavMeshAgent>().gameObject;

                branch_dialogue_manager.talking_npc = npc_talking;

                branch_dialogue_manager.ShowDialogue();
            }
        }
    }
}
