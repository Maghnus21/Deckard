using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealthUI : MonoBehaviour
{
    public Canvas canvas;
    public Image player_hp;
    public Image player_nrg;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // THIS IS A TEST TO READ PLAYER HEALTH, DAMAGE RECIEVED VIA KEYBOARD INPUT. CHANGED TO DAMAGE RECIEVED LATER
        // .fillAmount NOT WORKS, USE LOCALSCALE INSTEAD
        // STATUS BARS NEED TO BE ALTERED IN PHOTOSHOP
        /*
        if (Input.GetKeyDown(KeyCode.H))
        {
            player_hp.rectTransform.localScale += new Vector3(-0.1f, 0f, 0f);
            
        }else if (Input.GetKeyDown(KeyCode.N))
        {
            player_nrg.rectTransform.localScale += new Vector3(-0.1f, 0f, 0f);
        }
        */
    }

    public void reduceHP(float damage)
    {
        float percentage = damage / 100;
        player_hp.rectTransform.localScale += new Vector3(-percentage, 0f, 0f);
    }

    public void reduceEnergy(float charge)
    {
        float percentage = charge / 100;
        player_hp.rectTransform.localScale += new Vector3(-percentage, 0f, 0f);
    }
}
