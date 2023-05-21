using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHideObject : MonoBehaviour
{
    public AudioManager audio_man;
    public AudioSource source;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            audio_man.PlaySound(source, source.clip);

            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }
            
    }
}
