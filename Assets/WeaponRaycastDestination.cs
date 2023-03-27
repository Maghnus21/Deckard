using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRaycastDestination : MonoBehaviour
{
    Camera main_camera;

    Ray ray;
    RaycastHit hit;


    // Start is called before the first frame update
    void Start()
    {
        main_camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        ray.origin = main_camera.transform.position;
        ray.direction = main_camera.transform.forward;
        Physics.Raycast(ray, out hit);
        transform.position = hit.point;
    }
}
