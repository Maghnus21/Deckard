using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCheck : MonoBehaviour
{
    public int keycode = 0000;

    public AudioSource audio_source;
    public AudioClip accept, deny;

    public doorLogic door_logic;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckKeycode(List<Item> items)
    {
        Item key = null;
        bool accept_key = false;

        foreach(Item item in items)
        {
            if(item.is_key) key = item;

            if (key != null && key.keycode == keycode) AllowEntry();
            
        }


    }

    public void DenyEntry()
    {
        audio_source.clip = deny;
        audio_source.Play();
    }

    public void AllowEntry()
    {
        audio_source.clip = accept;
        audio_source.Play();

        door_logic.Open(GameObject.FindGameObjectWithTag("Player").transform.position);
    }
}
