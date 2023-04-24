using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item_specs;
    GameObject main_object;

    public AudioManager audio_man;
    public AudioClip clip;

    public UIManager ui_man;

    private void Start()
    {
        main_object = GetComponentInParent<Rigidbody>().gameObject;
        
    }

    public void PickUpItem(PlayerInventory player_inv)
    {
        player_inv.player_inventory.Add(item_specs);

        string pickup = ("picked_up: [" + item_specs.item_name + "]");

        ui_man.DisplayPickupItemText(pickup);

        Destroy(main_object);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<PlayerInventory>())
        {
            if(clip != null)audio_man.PlaySound(other.GetComponentInChildren<AudioSource>(), clip);
            

            PickUpItem(other.GetComponentInParent<PlayerInventory>());
        }
    }
}
