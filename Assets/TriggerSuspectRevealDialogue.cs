using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSuspectRevealDialogue : MonoBehaviour
{
    public DialogueManager dialogue_manager;

    public TalkableEntity talking_entity;

    public AIAgent ai_agent;

    public DialogueTreeScriptableObject guzza_fake, guzza_real;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            if (ai_agent.has_been_interrogated)
            {
                if (ai_agent.interrogation_dialogue_tree.is_real_human)
                    talking_entity.phone_dialogue = guzza_real;
                else
                    talking_entity.phone_dialogue = guzza_fake;

                dialogue_manager.talking_npc = this.gameObject;
                dialogue_manager.ShowDialogue();

                this.enabled = false;
            }
                
    }
}
