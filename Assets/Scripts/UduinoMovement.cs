using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

/// <summary>
/// IF USING SCRIPT, TURN OFF rigidbodyMovement
/// 
/// 
/// 
/// </summary>



public class UduinoMovement : MonoBehaviour
{
    int but1, but2, but3c, but4c;

    private Vector3 playerMove;
    Vector3 move;

    public Rigidbody player_rb;
    public Transform player;


    public float speed = 5f;
    int plyr_for;


    // Start is called before the first frame update
    void Start()
    {
        UduinoManager.Instance.pinMode(5, PinMode.Input_pullup);
        UduinoManager.Instance.pinMode(6, PinMode.Input_pullup);

        UduinoManager.Instance.pinMode(8, PinMode.Input_pullup);
        UduinoManager.Instance.pinMode(9, PinMode.Input_pullup);
    }

    // Update is called once per frame
    void Update()
    {
        but1 = UduinoManager.Instance.digitalRead(5);
        but2 = UduinoManager.Instance.digitalRead(6);

        but3c = UduinoManager.Instance.digitalRead(8);
        but4c = UduinoManager.Instance.digitalRead(9);

        if (but1 == 1)
        {
            plyr_for = 1;
        }
        else if (but2 == 1)
        {
            plyr_for = -1;
        }
        else
        {
            plyr_for = 0;
        }







        playerMove = new Vector3(0f, 0f, plyr_for * speed);

        MovePlayer();
    }


    void MovePlayer()
    {
        move = player.transform.TransformDirection(playerMove) * speed;

        player_rb.velocity = new Vector3(move.x, move.y, move.z);
    }
}