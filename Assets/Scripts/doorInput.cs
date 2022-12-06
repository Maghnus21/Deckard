using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorInput : MonoBehaviour
{
    RaycastHit hit;
    float open_dis = 3f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, open_dis))
        {
            if (hit.collider.TryGetComponent<doorLogic>(out doorLogic doorLogic) && Input.GetKeyDown(KeyCode.F))
            {
                if (doorLogic.IsOpen)
                {
                    doorLogic.Close();
                }
                else
                {
                    doorLogic.Open(transform.position);
                }
            }
        }
    }
}