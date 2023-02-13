using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponWheelButton : MonoBehaviour
{
    private Animator anim;
    bool selected = false;

    public UISOT demo;
    public GameObject player;
    public Image button_image;
    private ColorBlock cb;
    private Color normal_colour;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        cb = GetComponent<Button>().colors;
        normal_colour = cb.normalColor;

        button_image.sprite = demo.button_image;
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            Debug.Log("Selected button");
        }
    }

    public void Selected()
    {
        selected = true;
        player.GetComponent<AudioSource>().clip = demo.clip;
        player.GetComponent<AudioSource>().Play();
    }

    public void Deselected()
    {
        selected = false;
        
    }

    public void HoverEnter()
    {
        anim.SetBool("hover", true);
    }

    public void HoverExit()
    {
        anim.SetBool("hover", false);
        
    }
}
