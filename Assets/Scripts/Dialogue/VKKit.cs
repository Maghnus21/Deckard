using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VKKit : MonoBehaviour
{

    public Camera kit_cam;
    public GameObject suspect;
    public GameObject vk_button1 = null, vk_button2 = null, vk_button3 = null;

    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        kit_cam = GetComponentInChildren<Camera>();
    }
}
