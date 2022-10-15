using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vkTestScript : MonoBehaviour
{
    GameObject manager;

    public Camera camera;

    RaycastHit hit;
    Ray ray;
    float ray_length = 5f;

    // Start is called before the first frame update
    void Start()
    {
        //camera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, ray_length) && Input.GetButtonDown("Fire1"))
        {
            switch (hit.collider.gameObject.name)
            {
                case "button1": Debug.Log("HIT BUTTON 1");
                    break;
                case "button2": Debug.Log("HIT BUTTON 2");
                    break;
                case "button3": Debug.Log("HIT BUTTON 3");
                    break;
                default:    Debug.Log("HIT " + hit.collider.gameObject.name);
                    break;
            }
        }
    }
}
