using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSuspectUserDialogue : MonoBehaviour
{
    public TalkableEntity entity;

    public AIAgent ai_agent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (entity.interacted_with)
        {
            ai_agent.has_been_interrogated = true;

            ai_agent.dialogue_tree = ai_agent.interrogation_dialogue_tree.post_interrogation_dialogue;
        }
    }
}
