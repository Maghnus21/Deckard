using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Uduino;
using UnityEngine;

public class UduinoPlayerCameraMovement : MonoBehaviour
{
    public player_look p_l;
    public Camera player_camera;
    public Transform player_body;
    public Transform player_weapon;
    public int x_axis, y_axis;
    int base_x, base_y;

    float xRotation;
    // Start is called before the first frame update
    void Start()
    {
        UduinoManager.Instance.pinMode(AnalogPin.A0, PinMode.Input);
        UduinoManager.Instance.pinMode(AnalogPin.A1, PinMode.Input);

        //  base values for joystick
        base_x = UduinoManager.Instance.analogRead(AnalogPin.A0);
        base_y = UduinoManager.Instance.analogRead(AnalogPin.A1);
    }

    // Update is called once per frame
    void Update()
    {
        x_axis = UduinoManager.Instance.analogRead(AnalogPin.A0);
        y_axis = UduinoManager.Instance.analogRead(AnalogPin.A1);
        float x_dir = 0f, y_dir = 0f;

        if (x_axis >= base_x + 5f)
            x_dir = 1f;
        else if (x_axis <= base_x - 5f)
            x_dir = -1f;
        else
            x_dir = 0f;


        if (y_axis >= base_y + 5f)
            y_dir = 1f;
        else if (y_axis <= base_y - 5f)
            y_dir = -1f;
        else
            y_dir = 0f;


        xRotation -= x_dir;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        player_camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player_body.Rotate(Vector3.up * y_dir);
        player_weapon.localRotation = player_camera.transform.localRotation;
    }
}