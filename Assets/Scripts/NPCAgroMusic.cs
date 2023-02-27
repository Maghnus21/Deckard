using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAgroMusic : MonoBehaviour
{
    public AudioClip fight_music;
    public AudioSource audio_source;

    public bool play_audio = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playMusic()
    {
        audio_source.clip = fight_music;

        if (play_audio)
        {
            if (audio_source.isPlaying)
            {

            }
            else
            {
                audio_source.Play();
            }
        }
        
    }
}
