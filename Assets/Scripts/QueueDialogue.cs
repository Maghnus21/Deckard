using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueDialogue : MonoBehaviour
{
    public Dialogue dialogue;
    public NPC npc;




    private void Awake()
    {
        dialogue.dialogue = npc.dialogue;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerQueueDialogue()
    {
        FindObjectOfType<oldDialogueManager>().StartDialogueQueue(dialogue);
    }
}
