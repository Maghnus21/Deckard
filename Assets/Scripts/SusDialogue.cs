using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusDialogue : MonoBehaviour
{
    public Dialogue dialogue;
    public Camera camera;

    RaycastHit hit;
    Ray ray;
    float ray_length = 3f;

    void Update()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, ray_length) && Input.GetButtonDown("Fire1"))
        {
            TriggerDialogue();
        }
    }


    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
