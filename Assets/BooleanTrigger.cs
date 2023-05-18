using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooleanTrigger : MonoBehaviour
{
    public bool entered_trigger = false;
    public bool disable_upon_enter = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            entered_trigger = true;

            if(disable_upon_enter)
                this.enabled = false;
        }
            
    }
}
