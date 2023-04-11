using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshSwitch : MonoBehaviour
{
    public GameObject[] unbroken_objects;
    public GameObject[] broken_objects;
    Health health;

    public AudioSource audio_source;

    bool is_broken = false;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (health.health <= 0f)
        {
            foreach (GameObject obj in unbroken_objects)
            {
                obj.SetActive(false);
            }

            foreach (GameObject obj in broken_objects)
            {
                obj?.SetActive(true);
            }

            if (!is_broken && audio_source.clip != null)
            {
                audio_source.Play();
                is_broken = true;
            }



        }
    }
}
