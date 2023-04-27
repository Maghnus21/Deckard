using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_look : MonoBehaviour
{

    #region variables

    public Transform body;

    // reference to active weapon
    public Transform weapon;

    //  referencce to item_slot empty game object. holds item at item_slot local position. no rotation on x axis so item will remain upright
    public Transform itemTransform;
    Vector3 itemRotation;
    float itemDistance = 3f;

    public int mouse_sen = 10;
    float mouseX, mouseY, xRotation = 0f;


    #endregion

    // Start is called before the first frame update
    void Start()
    {
        itemDistance = itemTransform.position.z - transform.position.z;   

        Cursor.lockState = CursorLockMode.Confined;
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouse_sen * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouse_sen * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        body.Rotate(Vector3.up * mouseX);
        

        // for rotating weapon with camera
        weapon.localRotation = transform.localRotation;

        //itemTransform.position = transform.position + transform.forward * itemDistance;
    }
}
