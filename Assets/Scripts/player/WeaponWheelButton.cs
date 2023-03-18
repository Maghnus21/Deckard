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

    public int stack_location = 12;
    public weapon weapon_script;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        cb = GetComponent<Button>().colors;
        normal_colour = cb.normalColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            Debug.Log("Selected button");
            selected = !selected;
        }
    }

    public void Selected()
    {
        if(stack_location == 12)
        {
            print("No weapon/item in slot " + name);
            return;
        }
        else
        {
            selected = true;
            player.GetComponent<AudioSource>().clip = demo.clip;
            player.GetComponent<AudioSource>().Play();

            weapon_script = player.GetComponent<weapon>();

            weapon_script.Equip(stack_location);
        }

        Deselected();
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
