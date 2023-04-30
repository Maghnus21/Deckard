using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

/// <summary>
/// If wanting to add player ragdoll death, need to make seperate body with ragdoll, destroy player body and instantiate ragdoll clone on death
/// 
/// with current controller using rigidbody, it is impossible to use a ragdoll on death otherwise
/// </summary>



public class rigidbodyMovement : MonoBehaviour
{
    public AudioManager audio_man;
    public AudioClip jump_clip;
    public AudioSource audio_source;


    private Vector3 player_movement;
    Vector3 move_vec;

    public Rigidbody player_body;
    public CapsuleCollider c_collider;

    public LayerMask avoid_layer;

    public float speed;
    public float sprint;
    public float jump;

    bool is_crouching = false;
    public bool is_climbing = false;

    public bool can_jump = true;

    // Start is called before the first frame update
    void Start()
    {
        audio_source = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        player_movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        MovePlayer();
    }

    private void MovePlayer()
    {

        if (Physics.CheckSphere(transform.position, .1f, 1 << avoid_layer))
        {
            can_jump = true;
        }
        else can_jump = false;

        if (Input.GetKey(KeyCode.LeftControl))
        {
            PlayerCrouch();
        }
        else
        {
            PlayerStand();
        }

        //  player speeds up to sprint speed
        //  MUST BE PLACED AFTER CROUCH CHECK TO WORK
        if (Input.GetKey(KeyCode.LeftShift) && is_crouching == false)
        {
            move_vec = transform.TransformDirection(player_movement) * sprint;
        }


        //  climbing works but issue arrives when user enters another ladder. is_climbing returns to false and prevents climbing the second ladder
        if (!is_climbing)
        {
            player_body.useGravity = true;
            player_body.velocity = new Vector3(move_vec.x, player_body.velocity.y, move_vec.z);
        }
        else
        {
            //  equates to precentile value of 0 - 100 % depending on the rotation of the main camera's x axis rotation, 0 - 90 degrees.
            float camera_multi = 1 / Camera.main.transform.localRotation.x;

            //  making player camera rotation tied to ladder movement allows for player to look in direction they want to travel 
            player_body.useGravity = false;
            if (Input.GetKey(KeyCode.W))
            {
                Vector3 climb = new Vector3(transform.position.x, transform.position.y - .1f / camera_multi, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, climb, 1f);
            }
            if (Input.GetKey(KeyCode.S))
            {
                Vector3 climb = new Vector3(transform.position.x, transform.position.y + .1f / camera_multi, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, climb, 1f);
            }
            if (Input.GetKeyDown(KeyCode.Space) )
            {
                player_body.AddForce(Camera.main.transform.forward * jump, ForceMode.Impulse);
            }
            
        }
        

        if (Input.GetKeyDown(KeyCode.Space) && can_jump)
        {
            if (audio_man != null && jump_clip != null )
                audio_man.PlaySound(audio_source, jump_clip);

            player_body.AddForce(Vector3.up * jump, ForceMode.VelocityChange);
        }
    }

    void PlayerCrouch()
    {
        is_crouching = true;

        //  linearally interpolates between current position and crouching position 
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, GameObject.Find("player/CameraRecoilParent/camera/CameraPositions/crouch").transform.position, Time.deltaTime * 5f);// GameObject.Find("player/camera/CameraPositions/crouch").transform.position;

        //  changes height of character by half and moves center of character collider from 1 to 0.5
        c_collider.height = 1f;
        c_collider.center = new Vector3(0f, 0.5f, 0f);



        //  movement speed reduced to 75 percent of normal walking speed
        move_vec = transform.TransformDirection(player_movement) * speed / 2;


        //  linearally interpolates between current position and crouching position
        GameObject.Find("player/weapon").transform.position = Vector3.Lerp(GameObject.Find("player/weapon").transform.position, GameObject.Find("player/CameraRecoilParent/camera/CameraPositions/crouch").transform.position, Time.deltaTime * 5f);
    }

    void PlayerStand()
    {
        is_crouching = false;

        //  linearally interpolates between current position and standing position 
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, GameObject.Find("player/CameraRecoilParent/camera/CameraPositions/stand").transform.position, Time.deltaTime * 4f);

        //  changes height of character to 2 and moves center of character collider from 0.5 to 1
        c_collider.height = 2f;
        c_collider.center = new Vector3(0f, 1f, 0f);

        //  movement speed at 100 percent
        move_vec = transform.TransformDirection(player_movement) * speed;

        //  linearally interpolates between current position and standing position
        GameObject.Find("player/weapon").transform.position = Vector3.Lerp(GameObject.Find("player/weapon").transform.position, GameObject.Find("player/CameraRecoilParent/camera/CameraPositions/stand").transform.position, Time.deltaTime * 5f);

    }
}
