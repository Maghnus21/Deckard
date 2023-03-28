using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonPress : MonoBehaviour
{
    public AudioClip click_sound;

    public void OnPress()
    {
        print("Pressed " + name);
        Camera.main.GetComponent<AudioSource>().clip = click_sound;
        Camera.main.GetComponent<AudioSource>().Play();
    }
}
