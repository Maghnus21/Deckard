using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStates : MonoBehaviour
{
    GameObject player;
    playerInteractable PlayerInteractable;

    // PUBLICALLY ACCESSABLE STATES
    public bool look_at_interactable;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        PlayerInteractable = player.GetComponent<playerInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        look_at_interactable = PlayerInteractable.looking_at_interactable;
    }
}
