using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiftControlls : MonoBehaviour
{
    RaycastHit hit;
    Ray ray;

    float range = 3f;

    LiftButtons lift_buttons;
    public Image is_looking_at;

    // Start is called before the first frame update
    void Start()
    {
        is_looking_at.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward * range);
        Debug.DrawRay(ray.origin, ray.direction);

        if(Physics.Raycast(ray, out hit, range) && hit.collider.CompareTag("LiftButton"))
        {
            is_looking_at.enabled=true;

            if (Input.GetKeyDown(KeyCode.F))
            {
                GameObject button = hit.collider.gameObject;
                lift_buttons = button.GetComponent<LiftButtons>();

                lift_buttons.LiftMovement();
            }
        }
    }
}
