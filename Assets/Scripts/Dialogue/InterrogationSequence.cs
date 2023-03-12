using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterrogationSequence : MonoBehaviour
{

    public Camera kit_cam;
    public GameObject suspect;

    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        kit_cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (!kit_cam.enabled)
        {
            return;
        }
        else
        {

            if(Physics.Raycast(kit_cam.ScreenPointToRay(kit_cam.transform.position), out hit))
            {
                if (hit.collider.GetComponent<DialogueBranchButton>())
                {
                    print(suspect.GetComponent<InterrogationDialogueTree>().branches[0].sections[0].responses[0]);
                }
            }

            
        }

    }
}
