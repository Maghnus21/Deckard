using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudio : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    public bool play_clip;
    public bool disable_on_enter = false;

    // Start is called before the first frame update
    void Start()
    {
        if(source == null)
        {
            source = gameObject.AddComponent<AudioSource>();
            source.clip = clip;
            source.loop = false;
            source.playOnAwake = false;
            source.spatialBlend = 1f;
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        if (play_clip)
        {
            source.clip = clip;
            source.Play();
            play_clip = false;
        }
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            source.Play();
            if (disable_on_enter)
                this.enabled = false;
        }
            
    }
}
