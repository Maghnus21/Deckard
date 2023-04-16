using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item_specs;

    public void PickUpItem(PlayerInventory player_inv)
    {
        player_inv.items.Add(item_specs);

        Destroy(gameObject);
    }
}
