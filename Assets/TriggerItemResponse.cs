using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerItemResponse : MonoBehaviour
{
    public UIManager ui_man;

    public Item trigger_item;

    // Start is called before the first frame update
    void Start()
    {
        ui_man = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerInventory>())
            foreach (Item item in other.GetComponent<PlayerInventory>().player_inventory)
                if (item == trigger_item)
                {
                    ui_man.DisplayPlainText("I should deposit the eye in the police station");

                    this.enabled = false;
                }
        
    }
}
