using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class playerPickup : MonoBehaviour
{
    RaycastHit hit;
    public float range;
    public LayerMask playerMask;

    bool holding_obj = false;

    GameObject thrownObject;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * range, color: Color.green);

        if (Input.GetKeyDown(KeyCode.F) && transform.childCount == 0)
        {
            PickUpObject();
        }
        else if (Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(1) && transform.childCount > 0)
        {
            DetatchObject();
        }

        if(Input.GetMouseButtonDown(0) && transform.childCount > 0)
        {
            playerThrow();
        }
    }
    
    void playerThrow()
    {
        holding_obj = false;

        thrownObject.GetComponent<Rigidbody>().isKinematic = false;

        this.gameObject.transform.DetachChildren();

        thrownObject.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 7f, ForceMode.Impulse);

    }

    void DetatchObject()
    {
        holding_obj = false;

        transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
        this.gameObject.transform.DetachChildren();

        thrownObject = null;
    }

    void PickUpObject()
    {
        //  bitshifting playermask lets raycast pass through player collider and pick up objects within clamp range
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range, 1 << playerMask) && hit.collider.CompareTag("Pickup"))
        {
            if (hit.collider.GetComponent<Rigidbody>().isKinematic == false)
            {
                hit.collider.GetComponent<Rigidbody>().isKinematic = true;
            }

            holding_obj = true;


            hit.collider.transform.parent = transform;
            hit.collider.transform.localPosition = Vector3.zero;
            hit.collider.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);

            thrownObject = hit.collider.gameObject;
        }
    }
}
