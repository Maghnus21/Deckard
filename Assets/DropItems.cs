using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItems : MonoBehaviour
{
    public List<Item> items;

    Vector3 drop_point;

    private void Start()
    {
        drop_point = transform.position;
    }

    public void DropItemsInList()
    {
        foreach(Item item in items)
        {
            Instantiate(item.item_prefab, drop_point, transform.rotation).GetComponent<Rigidbody>().isKinematic = true;
            
        }

        items.Clear();
    }
}
