using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float health;
    public GameObject playerBody;
    Rigidbody[] rigidbodies;
    public Camera death_cam;

    bool is_player_alive;


    void Awake()
    {
        
    }


    // Start is called before the first frame update
    void Start()
    {
        PlayerAlive();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerDeath();
        }
    }

    void PlayerDeath()
    {
        is_player_alive=false;

        rigidbodies = playerBody.GetComponentsInChildren<Rigidbody>();

        foreach(var rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = false;
        }

        death_cam.gameObject.SetActive(true);
       
        Camera.main.gameObject.SetActive(false);
    }

    void PlayerAlive()
    {
        is_player_alive = true;

        rigidbodies = playerBody.GetComponentsInChildren<Rigidbody>();

        foreach (var rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = true;
        }
    }
}
