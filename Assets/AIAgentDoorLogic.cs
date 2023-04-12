using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAgentDoorLogic : MonoBehaviour
{
    public doorLogic door_logic;

    private void Awake()
    {
        door_logic = GetComponentInChildren<doorLogic>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponentInParent<AIAgent>() && other.GetComponentInParent<AIAgent>().enabled)
        {
            door_logic.Open(other.transform.position);
        }
    }
}
