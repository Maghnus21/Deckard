using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item_specs;
    GameObject main_object;

    private void Start()
    {
        main_object = GetComponentInParent<Rigidbody>().gameObject;
        
    }

    public void PickUpItem(PlayerInventory player_inv)
    {
        player_inv.player_inventory.Add(item_specs);

        Destroy(main_object);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<PlayerInventory>())
        {
            PickUpItem(other.GetComponentInParent<PlayerInventory>());
        }
    }
}
