using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSway : MonoBehaviour
{
    public float intensity;
    public float smoothness;

    private Quaternion origin_rotation;

    private void Start()
    {
        origin_rotation = transform.localRotation;
    }


    // Update is called once per frame
    void Update()
    {
        SwayUpdate();
    }

    private void SwayUpdate()
    {
        float mouse_x = Input.GetAxis("Mouse X");
        float mouse_y = Input.GetAxis("Mouse Y");

        Quaternion x_sway = Quaternion.AngleAxis(-intensity * mouse_x, Vector3.up);
        Quaternion y_sway = Quaternion.AngleAxis(intensity * mouse_y, Vector3.right);
        Quaternion target_rotation = origin_rotation * x_sway * y_sway;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, target_rotation, Time.deltaTime * smoothness);
    }
}
