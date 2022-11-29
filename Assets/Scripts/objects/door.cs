using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class door : MonoBehaviour
{
    bool door_clsd;
    bool opn_door;

    public bool enable_plyr_tracking = false;

    public Transform player;
    public Transform anchor;
    public GameObject audio;

    Vector3 playerDir;
    Quaternion start_rot;
    Quaternion end_rot;
    Quaternion delta_rot;
    
    float angle;
    public float open_speed = 5f;
    

    private void Awake()
    {
        door_clsd = true;
        opn_door = false;
        start_rot = transform.localRotation;

        delta_rot = Quaternion.Euler(new Vector3(0f, -90f, 0f));
        end_rot = start_rot * delta_rot;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {

            opn_door = !opn_door;
            if (opn_door)
            {
                audio.GetComponent<AudioSource>().Play();
            }
        }

        switch (opn_door)
        {
            case true:
                openDoor();
                break;
            case false:
                closeDoor();
                break;
        }
    }

    void openDoor()
    {
        if(this.gameObject.transform.localRotation != end_rot)
        {
            getAngle(enable_plyr_tracking);

            Quaternion pos = transform.localRotation;

            Quaternion rot = end_rot;

            this.gameObject.transform.localRotation = Quaternion.Lerp(pos, rot, open_speed * Time.deltaTime);
        }
        else
        {
            door_clsd = false; 
        }
    }

    void closeDoor()
    {
        if (this.gameObject.transform.localRotation != start_rot)
        {
            Quaternion pos = transform.localRotation;

            Quaternion rot = start_rot;

            this.gameObject.transform.localRotation = Quaternion.Lerp(pos, rot, open_speed * Time.deltaTime);
        }
        else
        {
            door_clsd = true;
        }
    }

    void getAngle(bool enable)
    {
        playerDir = player.position - anchor.position;

        //  if angle is greater than 90 degrees, rot y will be -90f. if less than or equal to 90, rot y will be 90f
        if ((angle = Vector3.Angle(playerDir, anchor.transform.forward)) > 90f && enable)
        {
            delta_rot = Quaternion.Euler(new Vector3(0f, -90f, 0f));
            end_rot = start_rot * delta_rot;
        }
        else if ((angle = Vector3.Angle(playerDir, anchor.transform.forward)) < 90f && enable)
        {
            delta_rot = Quaternion.Euler(new Vector3(0f, 90f, 0f));
            end_rot = start_rot * delta_rot;
        }
    }
}
