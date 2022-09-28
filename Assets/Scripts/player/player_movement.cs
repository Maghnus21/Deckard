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

    

    int layerMask;



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

        layerMask = LayerMask.GetMask("Default");
    }

    // Update is called once per frame
    void Update()
    {
        if (is_grounded() && velocity.y < 0)
        {
            velocity.y = gravity;            
        }

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        move = transform.forward * z + transform.right * x;




        if(Input.GetKey(KeyCode.LeftShift) && is_grounded())
        {
            controller.Move(move * sprint * Time.deltaTime);
        }
        else
        {
            controller.Move(move * speed * Time.deltaTime);
        }

        



        if (Input.GetButtonDown("Jump") && is_grounded())
        {

            velocity.y = Mathf.Sqrt(jump_height * -2f * gravity);
        }


        velocity.y += (gravity)  * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        is_grounded_check = is_grounded();
    }

    private bool is_grounded()
    {
        return Physics.CheckSphere(transform.position, sphere_size, layerMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, sphere_size);
    }
}
