using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class branchDialogueManager : MonoBehaviour
{

    public GameObject talking_npc;
    public DialogueTree dialogue_tree;
    public InterrogationDialogueTree interrogation_dialogue_tree;
    public GameObject kit;


    public GameObject dialogue_box;
    public TextMeshProUGUI dialogue_text;
    public GameObject button1 = null, button2 = null, button3 = null;       //  pressable buttons for dialogue

    public GameObject player;
    public player_look p_l;

    public int branch_choice = 0;
    int response_choice = 0;

    int original_mouse_sensativity;

    bool in_convo = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        p_l = player.GetComponentInChildren<player_look>();

        original_mouse_sensativity = p_l.mouse_sen;

        kit.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (in_convo)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                HideDialogue();
                in_convo = !in_convo;
            }
        }
    }

    public void ShowDialogue()
    {
        in_convo = !in_convo;

        ParseDialogueInfo();
        ParseinterrogationDialogueInfo();

        p_l.mouse_sen = 0;

        

        dialogue_box.SetActive(true);

        DisplayConvo();
    }

    /// <summary>
    /// Hides the dialogue box, resets the mouse sensitivity and clears the talking_npc, dialogue_tree and interrogation_dialogue_tree fields
    /// </summary>
    public void HideDialogue()
    {
        p_l.mouse_sen = original_mouse_sensativity;

        //  clearing fields for next npc player will talk to
        talking_npc = null;
        dialogue_tree = null;
        interrogation_dialogue_tree = null;

        branch_choice = 0;
        response_choice = 0;


        dialogue_box.SetActive(false);
        kit.GetComponent<InterrogationSequence>().kit_cam.enabled = false;
    }

    /// <summary>
    /// Parses DialogueTree data to the dialogue_tree field if DialogueTree component is attached to talking_npc
    /// </summary>
    void ParseDialogueInfo()
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

    /// <summary>
    /// Parses InterrogationDialogueTree data to the interrogation_dialogue_tree field if InterrogationDialogueTree component is atttached to talking_npc
    /// </summary>
    void ParseinterrogationDialogueInfo()
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


    public void DisplayConvo()
    {
        dialogue_text.text = dialogue_tree.branches[branch_choice].sections[0].dialogue;

        DisplayResponses();
    }

    /// <summary>
    /// Reads number of dialogue responses and sets appropriate buttons as active 
    /// </summary>
    void DisplayResponses()
    {
        //  checks number of responses, turns off buttons depending on size of dialogue responses
        int responses_count = dialogue_tree.branches[branch_choice].sections[0].responses.GetLength(0);

        switch (responses_count)
        {
            case 1:     
                //  only sets button1 as active. rest are set is inactive
                button1.SetActive(true);
                button2.SetActive(false);
                button3.SetActive(false);

                //  configures button1 to display dialogue responses
                ConfigureButton(button1);
                break;

            case 2:     
                //  only sets button1 and button2 as active. button3 is set as inactive
                button1.SetActive(true);
                button2.SetActive(true);
                button3.SetActive(false);

                //  configures button1 and button2 to display dialogue responses
                ConfigureButton(button1);
                ConfigureButton(button2);
                break;

            case 3:
                //  sets all buttons as active
                button1.SetActive(true);
                button2.SetActive(true);
                button3.SetActive(true);

                //  configures all buttons to display appropriate dialogue responses 
                ConfigureButton(button1);
                ConfigureButton(button2);
                ConfigureButton(button3);
                break;

            default:
                break;

        }

        //  resets response_choice for next node of responses
        response_choice = 0;
    }

    /// <summary>
    /// Configures parsed button gameobject with a TextMeshProUGUI component with appropriate dialogue responses
    /// </summary>
    /// <param name="button">button gameobject to be configured</param>
    void ConfigureButton(GameObject button)
    {
        button.GetComponentInChildren<TextMeshProUGUI>().text = dialogue_tree.branches[branch_choice].sections[0].responses[response_choice].response_dialogue;

        if (!button.GetComponent<DialogueBranchButton>())
        {
            return;
        }
        else
        {
            button.GetComponent<DialogueBranchButton>().choice = response_choice;
            button.GetComponent<DialogueBranchButton>().branch_choice = dialogue_tree.branches[branch_choice].sections[0].responses[response_choice++].next_branch_id;      //  increments response_choice for next button
        }
    }

    public void UpdateConvo(int branch_choice, int response_choice)
    {
        if (dialogue_tree.branches[this.branch_choice].sections[0].responses[response_choice].end_on_response)
        {
            print("exited conversation");
            HideDialogue();
        } else if (dialogue_tree.branches[this.branch_choice].sections[0].responses[response_choice].initialize_interrogation)
        {
            HideDialogue();
            kit.SetActive(true);
            kit.GetComponent<InterrogationSequence>().kit_cam.enabled = true;
        }
        else
        {
            this.branch_choice = branch_choice;
            DisplayConvo();
            print("continued conversation");
        }

        
    }
}
