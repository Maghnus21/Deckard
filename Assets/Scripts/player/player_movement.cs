using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//https://www.youtube.com/watch?v=_QajrabyTJc&t=1204s


public class player_movement : MonoBehaviour
{
    CharacterController controller;

    // player variables
    [SerializeField] float speed = 5f, sprint = 10f, jump_height = 5f;

    // physics variables
    [SerializeField] float gravity = -9.81f;

    // groundcheck variables
    [SerializeField] float sphere_size = 0.4f;

    // private variables for movement
    float x, z;

    // vectors
    Vector3 velocity;
    Vector3 move;

    // boolean for surface-level debugging in editor, does not effect player
    bool is_grounded_check;


    bool is_crouching = false;


    public LayerMask playerLayer;


    float lean = 0f;


    // Start is called before the first frame update
    void Start()
    {
        // gets character controller component automatically
        controller = GetComponent<CharacterController>();


        // UPDATE LAYERMASK INTERGER WHEN FINAL LAYERS ARE DECIDED. BITSHIFT NECESSARY HEX CODE

        // as interger stores 32 bits (4 bytes), assigning "player" layermask gives us:
        // 00000000000000000000000000010000
        // by adding '~' bitwise operator, interger is inverted to:
        // 11111111111111111111111111101111
        // checkSphere now tricked into ignoring layer "player" and now returns true upon contact
        // with every other layer

        //layerMask =~ LayerMask.GetMask("PlayerBody");
    }

    // Update is called once per frame
    void Update()
    {
        if (is_grounded_check && velocity.y < 0)
        {
            velocity.y = -2f;            
        }

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        move = transform.forward * z + transform.right * x;


        
        if (Input.GetKeyDown(KeyCode.C))
        {

            //  inverts is_crouching bool to opposite. c acts as toggle
            is_crouching = !is_crouching;
        }

        if (is_crouching)
        {
            PlayerCrouch();
        }
        else
        {
            PlayerStand();

        }


        if (Input.GetKey(KeyCode.LeftShift) && is_grounded_check && !is_crouching)
        {
            controller.Move(move * sprint * Time.deltaTime);
        }
               
        

        






        if (Input.GetButtonDown("Jump") && is_grounded_check)
        {

            velocity.y = Mathf.Sqrt(jump_height * -2f * gravity);
        }





        velocity.y += (gravity * 2)  * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        is_grounded_check = isGrounded();
    }

    bool isGrounded()
    {
        return Physics.CheckSphere(transform.position, sphere_size, 1 << playerLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, sphere_size);
    }

    void PlayerCrouch()
    {
        //  linearally interpolates between current position and crouching position 
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, GameObject.Find("player/camera/CameraPositions/crouch").transform.position, Time.deltaTime * 5f);// GameObject.Find("player/camera/CameraPositions/crouch").transform.position;
        
        //  changes height of character by half and moves center of character collider from 1 to 0.5
        gameObject.GetComponent<CharacterController>().height = 1f;
        gameObject.GetComponent<CharacterController>().center = new Vector3(0f, .5f, 0f);

        //  movement speed reduced to 75 percent of normal walking speed
        controller.Move(move * (speed * 0.75f) * Time.deltaTime);


        //  linearally interpolates between current position and crouching position
        GameObject.Find("player/weapon").transform.position = Vector3.Lerp(GameObject.Find("player/weapon").transform.position, GameObject.Find("player/camera/CameraPositions/crouch").transform.position, Time.deltaTime * 5f);
    }

    void PlayerStand()
    {
        //  linearally interpolates between current position and standing position 
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, GameObject.Find("player/camera/CameraPositions/stand").transform.position, Time.deltaTime * 4f);

        //  changes height of character to 2 and moves center of character collider from 0.5 to 1
        gameObject.GetComponent<CharacterController>().height = 2f;
        gameObject.GetComponent<CharacterController>().center = new Vector3(0f, 1f, 0f);

        //  movement speed at 100 percent
        controller.Move(move * speed * Time.deltaTime);

        //  linearally interpolates between current position and standing position
        GameObject.Find("player/weapon").transform.position = Vector3.Lerp(GameObject.Find("player/weapon").transform.position, GameObject.Find("player/camera/CameraPositions/stand").transform.position, Time.deltaTime * 5f);

    }
}
