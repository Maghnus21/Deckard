using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class vkTestScript : MonoBehaviour
{
    // reference to ui_dialogue 
    public TextMeshProUGUI ui_dialogue;

    /*
    // reference to vk manager
    GameObject vk_manager;
    VKManager vkm;*/

    // reference to test script for suspect interactions
    public GameObject suspect;
    SuspectConvoTest suspectConvoTest;

    public Camera camera;

    RaycastHit hit;
    Ray ray;
    float ray_length = 5f;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        suspectConvoTest = suspect.GetComponent<SuspectConvoTest>();
    }

    // Update is called once per frame
    void Update()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, ray_length) && Input.GetButtonDown("Fire1"))
        {
            
            switch (hit.collider.gameObject.name)
            {
                case "button1": Debug.Log("HIT BUTTON 1");
                    suspectConvoTest.choice[i] = 1;
                    i++;
                    break;
                case "button2": Debug.Log("HIT BUTTON 2");
                    suspectConvoTest.choice[i] = 2;
                    i++;
                    //ui_dialogue.text = "button 2";
                    break;
                case "button3": Debug.Log("HIT BUTTON 3");
                    suspectConvoTest.choice[i] = 3;
                    i++;
                    //ui_dialogue.text = "button 3";
                    break;
                default:    Debug.Log("HIT " + hit.collider.gameObject.name);
                    break;
            }
            if(i == 3)
            {
                return;
            }
        }
    }
}
