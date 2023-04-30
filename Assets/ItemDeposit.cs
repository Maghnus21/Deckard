using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDeposit : MonoBehaviour
{
    public AudioManager audio_man;
    public AudioClip accept, deny;

    public UIManager ui_man;

    public AudioSource audio_source;

    public Item deposit_item;

    public bool accepted_depot = false;

    // Start is called before the first frame update
    void Start()
    {
        ui_man = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DepositItem(List<Item> items)
    {
        bool correct_item = false;

        foreach(Item item in items) 
        {
            if (item == deposit_item)
            {
                correct_item = true;
                AccreptItem();
                this.enabled = false;
                return;
            }
            correct_item = false;
            
        }

        if(!correct_item)
            DenyItem();


    }

    void AccreptItem()
    {
        audio_man.PlaySound(audio_source, accept);
        ui_man.DisplayPlainText("Deposited eye");
        accepted_depot = true;
    }

    void DenyItem()
    {
        audio_man.PlaySound(audio_source, deny);
    }
}
