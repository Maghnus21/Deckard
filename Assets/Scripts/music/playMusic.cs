using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playMusic : MonoBehaviour
{
    public AudioClip music;
    AudioSource audioSource;

    Collider collider;

    bool toggle = false;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = music;
    }

    // Update is called once per frame
    void Update()
    {
        switch (toggle)
        {
            case true: audioSource.Play();
                Debug.Log("Play music");
                break;
            case false: audioSource.Stop();
                Debug.Log("Stop music");
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //audioSource = collider.gameObject.GetComponent<AudioSource>();

        toggle = !toggle;
    }
}
