using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class UduinoPlayerRBMovement : MonoBehaviour
{
    public rigidbodyMovement rb_movement;

    private int w_button, s_button, a_button, d_button;


    int z_dir = 0, x_dir = 0;

    public float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        UduinoManager.Instance.pinMode(11, PinMode.Input_pullup);
        UduinoManager.Instance.pinMode(10, PinMode.Input_pullup);
        UduinoManager.Instance.pinMode(9, PinMode.Input_pullup);
        UduinoManager.Instance.pinMode(8, PinMode.Input_pullup);
    }

    // Update is called once per frame
    void Update()
    {
        w_button = UduinoManager.Instance.digitalRead(11);
        s_button = UduinoManager.Instance.digitalRead(10);

        a_button = UduinoManager.Instance.digitalRead(9);
        d_button = UduinoManager.Instance.digitalRead(8);

        if(w_button>0)
            z_dir = 1;
        else if(s_button>0)
            z_dir = -1;
        else
            z_dir = 0;



        if (d_button > 0)
            x_dir = 1;
        else if (a_button > 0)
            x_dir = -1;
        else
            x_dir = 0;



        rb_movement.PlayerMovement(new Vector3(x_dir * speed, 0f, z_dir * speed));

        rb_movement.ExternalMovePlayer();

        //rb_movement.ExternalMovePlayer();
    }


}
