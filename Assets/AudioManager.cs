using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public void PlaySound(AudioSource audio, AudioClip clip)
    {
        audio.clip = clip;
        audio.Play();

        print("PLAYED AUDIO");
    }
}
