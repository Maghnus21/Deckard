using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDisableAudio : MonoBehaviour
{
    public AudioSource audio_device;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            audio_device.Stop();
    }
}
