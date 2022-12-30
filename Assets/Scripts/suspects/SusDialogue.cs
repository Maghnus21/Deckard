using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusDialogue : MonoBehaviour
{
    public Dialogue dialogue;
    new Camera camera;

    public GameObject kit;

    public float aggression = 0;

    RaycastHit hit;
    Ray ray;
    float ray_length = 3f;


    /// <summary>
    ///  i is used to pass array element to be displayed to dialogueManager.
    ///  buttons_pressed is amount of buttons pressed by character.
    ///  max_button_presses is how many buttons the player can press before interrogation is set is inactive. default is 3 due to current interrogation dialogue only containing 3 options
    ///  before exiting. this will need to be changed on a character-by-character basis if dialogue extends beyond 3 options
    /// </summary>

    int i = 0, buttons_pressed;

    public int max_button_presses = 3;


    void Awake()
    {
        kit.SetActive(false);
        this.gameObject.GetComponent<SusDialogue>().enabled = false;

        //  references child camera gameobject in the kit gameobject under camera. This is used for reading the buttons pressed
        camera = kit.GetComponentInChildren<Camera>();
    }

    void Update()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, ray_length) && Input.GetButtonDown("Fire1"))
        {

            switch (hit.collider.gameObject.name)
            {
                case "button1":
                    TriggerDialogue(i);
                    buttons_pressed++;
                    i += 3;

                    break;
                case "button2":
                    TriggerDialogue(i + 1);
                    aggression += 1;
                    buttons_pressed++;
                    i += 3;

                    break;
                case "button3":
                    TriggerDialogue(i + 2);
                    aggression += 2;
                    buttons_pressed++;
                    i += 3;

                    break;
                default:
                    Debug.Log("Raycast hit object: " + hit.collider.gameObject.name);
                    break;
            }



            if (buttons_pressed == max_button_presses)
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
