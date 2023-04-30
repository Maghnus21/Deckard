using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerItemDepot : MonoBehaviour
{
    public UIManager ui_man;

    public ItemDeposit item_depot;

    public AIAgent ai_agent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            if (item_depot.accepted_depot || ai_agent.has_been_interrogated)
                ui_man.DisplayPlainText("Thank you very much for playing the game");
    }
}
