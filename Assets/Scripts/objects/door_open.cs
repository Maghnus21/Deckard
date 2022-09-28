using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_open : MonoBehaviour
{
    GameObject player_manager;
    playerStates PlayerStates;

    bool open_state = false;
    bool look_state;

    
    // Start is called before the first frame update
    void Start()
    {
        player_manager = GameObject.Find("--<PLAYER MANAGER>--");

        PlayerStates = player_manager.GetComponent<playerStates>();

    }

    // Update is called once per frame
    void Update()
    {
        look_state = PlayerStates.look_at_interactable;

        if(Input.GetKeyDown(KeyCode.F) && look_state == true && open_state == false)
        {

            // Fine way of opening door, preferably rotate 90 degress on pivot
            //Destroy(gameObject);

            transform.Rotate(new Vector3(0f, -90f, 0f));
        }
    }
}
