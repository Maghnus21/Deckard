using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class branchDialogueManager : MonoBehaviour
{

    public GameObject talking_npc;
    public DialogueTree dialogue_tree;
    public InterrogationDialogueTree interrogation_dialogue_tree;


    public GameObject dialogue_box;
    public TextMeshProUGUI dialogue_text;
    public GameObject button1 = null, button2 = null, button3 = null;       //  pressable buttons for dialogue

    public GameObject player;
    public player_look p_l;

    int branch_choice = 0;
    int response_choice = 0;

    int original_mouse_sensativity;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        p_l = player.GetComponentInChildren<player_look>();

        original_mouse_sensativity = p_l.mouse_sen;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showDialogue()
    {
        parseDialogueInfo();
        parseinterrogationDialogueInfo();

        p_l.mouse_sen = 0;

        

        dialogue_box.SetActive(true);
        dialogue_text.enabled = true;
    }

    void parseDialogueInfo()
    {
        if (!talking_npc.GetComponent<DialogueTree>())
        {
            return;
        }
        else
        {
            dialogue_tree = talking_npc.GetComponent<DialogueTree>();
        }

    }

    void parseinterrogationDialogueInfo()
    {
        if (!talking_npc.GetComponent<InterrogationDialogueTree>())
        {
            return;
        }
        else
        {
            interrogation_dialogue_tree = talking_npc.GetComponent<InterrogationDialogueTree>();
        }
    }
}
