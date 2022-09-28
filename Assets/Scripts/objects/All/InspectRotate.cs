using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectRotate : MonoBehaviour
{
    public float degrees_per_second = 60f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, degrees_per_second, 0f) * Time.deltaTime);
    }
}
