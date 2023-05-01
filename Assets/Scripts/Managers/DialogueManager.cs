using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public UIManager ui_man;

    public GameObject talking_npc;
    public DialogueTreeScriptableObject dialogue_tree;
    public InterrogationDialogueTreeScriptableObject interrogation_dialogue_tree;
    public GameObject kit;


    public GameObject dialogue_box;
    public TextMeshProUGUI dialogue_text;
    public GameObject button1 = null, button2 = null, button3 = null;       //  pressable buttons for dialogue
    public GameObject vk_button1 = null, vk_button2 = null, vk_button3 = null;      //  interrogation button buttons

    public GameObject player;
    public player_look p_l;

    DialogueBranch dialogue_branch;

    int branch_choice = 0;
    int response_choice = 0;

    int original_mouse_sensativity;

    bool in_convo = false;
    bool in_interrogation = false;

    RaycastHit hit;
    Ray ray;

    Camera cam;

    public GameObject debug_cube;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ui_man = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        p_l = player.GetComponentInChildren<player_look>();

        original_mouse_sensativity = p_l.mouse_sen;

        kit.SetActive(false);

        HideDialogue();
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

        if (in_interrogation)
        {
            cam = kit.GetComponentInChildren<Camera>();

            ray = cam.ScreenPointToRay(Input.mousePosition);

           
            
                

            if(Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out hit) && hit.collider.GetComponent<VKButtons>())
                {
                    int branch_choice = hit.collider.GetComponent<VKButtons>().interrogation_branch_choice;
                    int response_choice = hit.collider.GetComponent<VKButtons>().interrogation_response_choice;

                    UpdateInterrogationConvo(branch_choice, response_choice);

                    print("HIT " + hit.collider.name);
                    //Instantiate(debug_cube, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.Euler(Vector3.zero));

                    print(hit.collider.GetComponent<VKButtons>().interrogation_branch_choice);

                }
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

        //in_convo = false;


        dialogue_box.SetActive(false);
        kit.GetComponent<VKKit>().kit_cam.enabled = false;
    }

    /// <summary>
    /// Parses DialogueTree data to the dialogue_tree field if DialogueTree scriptable object is attached to talking_npc AIAgent component
    /// </summary>
    void ParseDialogueInfo()
    {
        //  if dialogueTree is attached to npc, link it to dialogue_tree
        if (talking_npc.GetComponent<AIAgent>() && !talking_npc.GetComponent<AIAgent>().dialogue_tree)
        {
            print("no DialogueTree component attached to entity " + talking_npc.name);
            return;
        }
        if (talking_npc.GetComponent<TalkableEntity>() && !talking_npc.GetComponent<TalkableEntity>().phone_dialogue)
        {
            print("no DialogueTree component attached to entity " + talking_npc.name);
            return;
        }
        else
        {
            if (talking_npc.GetComponent<AIAgent>()) dialogue_tree = talking_npc.GetComponent<AIAgent>().dialogue_tree;
            else if (talking_npc.GetComponent<TalkableEntity>())
            {
                talking_npc.GetComponent<TalkableEntity>().interacted_with = true;
                dialogue_tree = talking_npc.GetComponent<TalkableEntity>().phone_dialogue;
            }
        }
    }

    /// <summary>
    /// Parses InterrogationDialogueTree data to the interrogation_dialogue_tree field if InterrogationDialogueTree component is atttached to talking_npc
    /// </summary>
    void ParseinterrogationDialogueInfo()
    {
        //  if interrogationDialoguetree exists on npc, link to interrogation_dialogue_tree
        if (talking_npc.GetComponent<AIAgent>() && !talking_npc.GetComponent<AIAgent>().interrogation_dialogue_tree)
        {
            print("no InterrogationDialogueTree component attached to entity " + talking_npc.name);
            return;
        }
        else
        {
            if (talking_npc.GetComponent<TalkableEntity>()) return;
            interrogation_dialogue_tree = talking_npc.GetComponent<AIAgent>().interrogation_dialogue_tree;
        }
    }


    public void DisplayConvo()
    {
        Cursor.visible = true;

        //  displays dialogue text in textbox
        
        foreach(DialogueBranch dialogueBranch in dialogue_tree.branches)
        {
            if (dialogueBranch.branch_id == branch_choice)
            { 
                dialogue_branch = dialogueBranch;
                dialogue_text.text = dialogueBranch.sections[0].dialogue;
            }
            else { }

            
        }
        
        //dialogue_text.text = dialogue_tree.branches[branch_choice].sections[0].dialogue;

        DisplayResponses();
    }

    /// <summary>
    /// Reads number of dialogue responses and sets appropriate buttons as active 
    /// </summary>
    void DisplayResponses()
    {
        //  checks number of responses, turns off buttons depending on size of dialogue responses
        int responses_count = dialogue_branch.sections[0].responses.GetLength(0);

        //  scitch case to vary amout of buttons displayed on display, along with configuring them for interaction
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
        
        //  button text is parsed the response dialogue
        button.GetComponentInChildren<TextMeshProUGUI>().text = dialogue_branch.sections[0].responses[response_choice].response_dialogue;

        if (!button.GetComponent<DialogueBranchButton>())
        {
            return;
        }
        else
        {
            button.GetComponent<DialogueBranchButton>().choice = response_choice;
            button.GetComponent<DialogueBranchButton>().branch_choice = dialogue_branch.sections[0].responses[response_choice++].next_branch_id;      //  increments response_choice for next button
        }
    }

    /// <summary>
    /// Updates the dialogue shown on screen
    /// </summary>
    /// <param name="branch_choice">Integer assigned to button parse from dialogue_tree's next_branch_id parameter</param>
    /// <param name="response_choice">Integer parsed from button script to chose respose to dialogue, 3 buttons = integer values of 0 -> 2</param>
    public void UpdateConvo(int branch_choice, int response_choice)
    {
        if (dialogue_branch.droppable_item != null)
        {
            GameObject dropped_item = Instantiate(dialogue_branch.droppable_item.item_prefab) as GameObject;
            dropped_item.transform.position = player.transform.position;

            StopAllCoroutines();
            ui_man.DisplayPickupItemText("picked_up: [" + dialogue_branch.droppable_item.item_name + "]");

            if (dialogue_branch.sections[0].responses[response_choice].end_on_response)
            {
                print("exited conversation");
                HideDialogue();
                in_convo = false;
            }
        }

        if (dialogue_branch.sections[0].responses[response_choice].end_on_response)
        {
            Cursor.visible = false;

            print("exited conversation");
            HideDialogue();
            in_convo = false;
        } else if (dialogue_branch.sections[0].responses[response_choice].initialize_interrogation)
        {
            print("begun interrogation");
            //HideDialogue();
            kit.SetActive(true);
            kit.GetComponent<VKKit>().kit_cam.enabled = true;
            in_convo = true;
            DisplayInterrogation();
        }
        else if (dialogue_branch.sections[0].responses[response_choice].turn_hostile)
        {
            Cursor.visible = false;

            talking_npc.GetComponent<AIAgent>().stateMachine.ChangeState(AIStateID.AttackPlayer);
            HideDialogue();
            in_convo = false;
        }
        
        else
        {
            

            this.branch_choice = branch_choice;
            DisplayConvo();
            print("continued conversation");
        }
    }


    //  Interrogation functions

    public void DisplayInterrogation()
    {
        in_interrogation = true;

        //ShowDialogue();

        dialogue_text.text = interrogation_dialogue_tree.branches[branch_choice].sections[0].dialogue;

        

        DisplayInterrogationResponses();
    }

    void DisplayInterrogationResponses()
    {
        int size = interrogation_dialogue_tree.branches[branch_choice].sections[0].responses.Length;

        switch (size)
        {
            case 1:
                button1.SetActive(true);
                button2.SetActive(false);
                button3.SetActive(false);
                break;
            case 3:
                button1.SetActive(true);
                button2.SetActive(true);
                button3.SetActive(true);
                break;
            default:
                button1.SetActive(true);
                button2.SetActive(true);
                button3.SetActive(true);
                print("Response length of " + interrogation_dialogue_tree.name + "exceeds max limit of 3. setting to default 3 responses");
                break;
        }
        
        //response_choice = 0;

        /*
        ConfigureInterrogationButton(button1);
        ConfigureInterrogationButton(button2);
        ConfigureInterrogationButton(button3);
        */
        response_choice = 0;
        ConfigureInterrogationButton(button1);
        ConfigureInterrogationButton(button2);
        ConfigureInterrogationButton(button3);
        //button1.GetComponentInChildren<TextMeshProUGUI>().text = interrogation_dialogue_tree.branches[0].sections[0].responses[0].response_dialogue;
        //button2.GetComponentInChildren<TextMeshProUGUI>().text = interrogation_dialogue_tree.branches[0].sections[0].responses[1].response_dialogue;
        //button3.GetComponentInChildren<TextMeshProUGUI>().text = interrogation_dialogue_tree.branches[0].sections[0].responses[2].response_dialogue;

        response_choice = 0;

        vk_button1 = kit.GetComponent<VKKit>().vk_button1;
        vk_button2 = kit.GetComponent<VKKit>().vk_button2;
        vk_button3 = kit.GetComponent<VKKit>().vk_button3;

        ConfigureVKButton(vk_button1);
        ConfigureVKButton(vk_button2);
        ConfigureVKButton(vk_button3);

    }

    void ConfigureVKButton(GameObject vk_button)
    {
        vk_button.GetComponent<VKButtons>().interrogation_response_choice = response_choice;
        vk_button.GetComponent<VKButtons>().interrogation_branch_choice = interrogation_dialogue_tree.branches[branch_choice].sections[0].responses[response_choice++].next_branch_id;

    }

    void ConfigureInterrogationButton(GameObject button)
    {
        button.GetComponentInChildren<TextMeshProUGUI>().text = interrogation_dialogue_tree.branches[branch_choice].sections[0].responses[response_choice].response_dialogue;

        if (!button.GetComponent<DialogueBranchButton>())
        {
            return;
        }
        else
        {
            button.GetComponent<DialogueBranchButton>().choice = response_choice;
            button.GetComponent<DialogueBranchButton>().branch_choice = interrogation_dialogue_tree.branches[branch_choice].sections[0].responses[response_choice++].next_branch_id;      //  increments response_choice for next button
        }
    }

    void UpdateInterrogationConvo(int branch_choice, int choice)
    {

        if (interrogation_dialogue_tree.branches[this.branch_choice].sections[0].responses[choice].end_on_response)
        {
            Cursor.visible = false;

            print("exited conversation");
            talking_npc.GetComponent<AIAgent>().has_been_interrogated = true;


            if (talking_npc.GetComponent<AIAgent>().aggression_level >= interrogation_dialogue_tree.reveal_human_type_level && talking_npc.GetComponent<AIAgent>().aggression_level < interrogation_dialogue_tree.turn_hostile_level)
                //  display text on screen to say suspect is human
                if (interrogation_dialogue_tree.is_real_human) ui_man.DisplayPickupItemText("suspect_type: [HUMAN]");
                // display text on screen saying suspect is fake, 
                else
                {
                    ui_man.DisplayPickupItemText("suspect_type: [ERSATZ]");
                    if (interrogation_dialogue_tree.post_interrogation_dialogue != null)
                        talking_npc.GetComponent<AIAgent>().dialogue_tree = interrogation_dialogue_tree.post_interrogation_dialogue;
                }

            else
                ui_man.DisplayPickupItemText("suspect_type: [UNKNOWN]");

            kit.SetActive(false);
            //  turns npc hostile if is aggressive is enabled
            if (talking_npc.GetComponent<AIAgent>().aggression_level >= interrogation_dialogue_tree.turn_hostile_level)
                talking_npc.GetComponent<AIAgent>().is_aggressive = true;

            

            HideDialogue();
            in_convo = false;
        }
        else
        {

            talking_npc.GetComponent<AIAgent>().aggression_level += interrogation_dialogue_tree.branches[this.branch_choice].sections[0].responses[choice].add_aggression;
            this.branch_choice = branch_choice;
            DisplayInterrogationConvo();
        }

            
    }

    void DisplayInterrogationConvo()
    {
        dialogue_text.text = interrogation_dialogue_tree.branches[branch_choice].sections[0].dialogue;

        DisplayInterrogationResponses();
    }

    
}
