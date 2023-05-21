using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftButtons : MonoBehaviour
{
    public AudioManager audio_man;
    public AudioSource source;
    public AudioClip selected;

    public AudioSource lift_audiosource;

    public GameObject lift;
    public Transform destination;
    public float speed = 10f;

    bool reached_des = true;

    private void Awake()
    {
        
    }

    private void Update()
    {
        if (!reached_des)
        {
            lift.transform.position = Vector3.MoveTowards(lift.transform.position, destination.position, speed * Time.deltaTime);
        }
        if(lift.transform.position == destination.position)
        {
            lift_audiosource.Stop();
            reached_des = true;
        }
    }   

    public void LiftMovement()
    {
        if (lift_audiosource != null)
            lift_audiosource.Play();

        audio_man.PlaySound(source, selected);

        reached_des = false;
    }

}
