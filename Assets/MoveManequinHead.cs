using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManequinHead : MonoBehaviour
{
    public List<Transform> transforms = new List<Transform>();

    public BooleanTrigger trigger;

    bool turning = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.entered_trigger && !turning)
        {
            transforms.ForEach(transform =>
            {
                transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);

            });
            turning = true;
        }
            
    }
}
