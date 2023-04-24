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
    public AudioSource player_audio;

    public AudioManager audio_man;
    public AudioClip clip;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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

        //if (thrownObject != null)
            //UpdateObjectRotation();
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
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if (Physics.Raycast(ray, out hit, range, 1 << playerMask))
        {
            if (hit.collider.CompareTag("Pickup") || hit.collider.CompareTag("EntityDead"))
            {
                audio_man.PlaySound(player_audio, clip);

                if (hit.collider.GetComponent<Rigidbody>().isKinematic == false)
                {
                    hit.collider.GetComponent<Rigidbody>().isKinematic = true;
                }

                holding_obj = true;


                hit.collider.transform.SetParent(transform, false);
                hit.collider.transform.localPosition = Vector3.zero;
                
                hit.collider.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);

                thrownObject = hit.collider.gameObject;
            }
            else { print("CAN PICKUP  OBJ"); }
        }
        
    }

    void UpdateObjectRotation()
    {
        thrownObject.transform.localRotation = Quaternion.Euler(0f, 0f, thrownObject.transform.localRotation.z);
    }
}
