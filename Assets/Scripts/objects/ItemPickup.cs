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

        ui_man = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();

    }

    public void PickUpItem(PlayerInventory player_inv)
    {
        player_inv.player_inventory.Add(item_specs);

        ui_man.DisplayPickupItemText(item_specs);

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
