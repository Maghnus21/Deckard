using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BranchDialogueConvo : MonoBehaviour
{
    public DialogueTree dialogue_tree;
    public InterrogationDialogueTree interrogation_dialogue_tree;

    public GameObject dialogue_box;
    public TextMeshProUGUI dialogue_text;
    public GameObject button1, button2, button3;
    
    public GameObject player;
    public player_look p_l;


    int branch_choice = 0;
    int response_choice = 0;

    int original_mouse_sen;


    private void Awake()
    {
        dialogue_tree = GetComponent<DialogueTree>();
        interrogation_dialogue_tree = GetComponent<InterrogationDialogueTree>();

        player = GameObject.FindGameObjectWithTag("Player");
        p_l = player.GetComponentInChildren<player_look>();


        original_mouse_sen = p_l.mouse_sen;
        
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
        p_l.mouse_sen = 0;

        dialogue_box.SetActive(true);
        dialogue_text.enabled = true;
    }
}
