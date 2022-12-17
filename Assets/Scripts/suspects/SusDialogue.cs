using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusDialogue : MonoBehaviour
{
    public Dialogue dialogue;
    public Camera camera;

    public GameObject kit;

    public float aggression = 0;

    RaycastHit hit;
    Ray ray;
    float ray_length = 3f;

    int i = 0;


    void Awake()
    {
        kit.SetActive(false);
        this.gameObject.GetComponent<SusDialogue>().enabled = false;
    }

    void Update()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, ray_length) && Input.GetButtonDown("Fire1"))
        {
            if(i <= 8)
            {
                switch (hit.collider.gameObject.name)
                {
                    case "button1":
                        TriggerDialogue(i);
                        i += 3;

                        break;
                    case "button2":
                        TriggerDialogue(i + 1);
                        aggression += 1;
                        i += 3;

                        break;
                    case "button3":
                        TriggerDialogue(i + 2);
                        aggression += 2;
                        i += 3;

                        break;
                    default:    Debug.Log("Raycast hit object: " + hit.collider.gameObject.name);
                        break;
                }

            }
            else
            {
                Debug.Log("FINISHED INTERROGAION");
                Invoke("endInterrogation", 5f);
            }
        }
    }


    public void TriggerDialogue(int i)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, i);
    }

    public void endInterrogation()
    {
        camera.enabled = false;
        kit.active = false;

        SusDialogue sus = gameObject.GetComponent<SusDialogue>();
        Destroy(sus);
    }
}
