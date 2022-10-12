using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterrogationInteract : MonoBehaviour
{
    public GameObject inter_camera;
    public GameObject main_camera;

    RaycastHit hit;
    Ray ray;
    float ray_length = 5f;

    // Start is called before the first frame update
    void Start()
    {
        inter_camera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, ray_length) && hit.collider.tag == "target" && Input.GetKeyDown(KeyCode.F))
        {
            main_camera.SetActive(false);
            inter_camera.SetActive(true);
        }
    }
}
