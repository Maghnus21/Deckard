using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VKManager : MonoBehaviour
{
    public GameObject vk_device;

    // testing dialogue output
    public string sus_dialogue;


    // reference to TextManager
    public GameObject tm;
    TextManager textmanager;

    // Awake is called when started
    void Awake()
    {
        textmanager = tm.GetComponent<TextManager>();
        vk_device.SetActive(false);
        sus_dialogue = null;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // testing code
        if (Input.GetKeyDown(KeyCode.K))
        {
            vk_device.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            vk_device.SetActive(false);
        }

        if(sus_dialogue != null)
        {
            textmanager.dialogue.text = sus_dialogue;
        }
    }
}
