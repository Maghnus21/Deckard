using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCheck : MonoBehaviour
{
    public int keycode = 0000;

    public AudioSource audio_source;
    public AudioClip accept, deny;

    public doorLogic door_logic;

    public Transform player_transform;

    public Light light;


    // Start is called before the first frame update
    void Start()
    {
        player_transform = GameObject.FindGameObjectWithTag("Player").transform;
        light.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckKeycode(bool open_door)
    {
        StopAllCoroutines();

        if (open_door) AllowEntry();
        else DenyEntry();

    }

    void DenyEntry()
    {
        StartCoroutine(DenyLight(1f));
    }

    void AllowEntry()
    {
        StartCoroutine(DelayOpenDoor(1f));
    }

    IEnumerator DelayOpenDoor(float time)
    {
        audio_source.clip = accept;
        audio_source.Play();

        light.enabled = true;
        light.color = Color.green;

        yield return new WaitForSeconds(time);

        light.enabled = false;
        door_logic.Open(player_transform.position);
    }

    IEnumerator DenyLight(float time)
    {
        audio_source.clip = deny;
        audio_source.Play();

        light.enabled = true;
        light.color = Color.red;

        yield return new WaitForSeconds(time);

        light.enabled = false;
    }
}
