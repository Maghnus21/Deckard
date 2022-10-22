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

    int i = 0;

    void Update()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, ray_length) && Input.GetButtonDown("Fire1"))
        {
            switch (hit.collider.gameObject.name)
            {
                case "button1": TriggerDialogue(i);
                    break;
                case "button2":
                    break;
                case "button3":
                    break;
                default:
                    break;
            }
        }
    }


    public void TriggerDialogue(int i)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, i);
    }
}
