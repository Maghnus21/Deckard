using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class objectDestruction : MonoBehaviour
{
    public GameObject object_breakable;

    bool is_broken = false;
    public AudioSource audio_source;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Obsolete]
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Instantiate(object_breakable, transform.position, transform.rotation);

            if(!is_broken && audio_source.clip != null)
            {
                audio_source.Play();
            }
        }
    }
}
