using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BranchDialogueTest : MonoBehaviour
{
    public DialogueTree dt;

    public TextMeshProUGUI text;
    Image dialogue_box;
    public Button op1, op2;

    int branch_choice;
    int choice;


    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        dt = GetComponent<DialogueTree>();

        dialogue_box = text.GetComponentInParent<Image>();

        /*
        dialogue_box.enabled = false;
        text.enabled = false;
        */

        showDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(op1.GetComponent<DialogueBranchButton>().is_pressed)
        {

            op1ButtonPress();

        }
        else if (op2.GetComponent<DialogueBranchButton>().is_pressed)
        {
            op2ButtonPress();
        }
    }

    public void showDialogue()
    {
        dialogue_box.enabled = true;
        text.enabled = true;

        print(dt.branches[0].sections[0].dialogue);
        text.text = dt.branches[0].sections[0].dialogue;


        op1.GetComponentInChildren<TextMeshProUGUI>().text = dt.branches[0].sections[0].responses[0].response_dialogue;
        op2.GetComponentInChildren<TextMeshProUGUI>().text = dt.branches[0].sections[0].responses[1].response_dialogue;
    }

    private void hideDialogue()
    {
        dialogue_box.enabled = false;
        text.enabled = false;

        print(dt.branches[0].sections[0].dialogue);
        text.text = "";


        op1.GetComponentInChildren<TextMeshProUGUI>().text = "";
        op2.GetComponentInChildren<TextMeshProUGUI>().text = "";
    }

    void updateDialogue(int num)
    {
        branch_choice = num;


        print(dt.branches[0].sections[0].dialogue);
        text.text = dt.branches[branch_choice].sections[0].dialogue;


        op1.GetComponentInChildren<TextMeshProUGUI>().text = dt.branches[branch_choice].sections[0].responses[0].response_dialogue;
        op2.GetComponentInChildren<TextMeshProUGUI>().text = dt.branches[branch_choice].sections[0].responses[1].response_dialogue;
    }

    void op1ButtonPress()
    {
        choice = op1.GetComponent<DialogueBranchButton>().choice;
        op1.GetComponent<DialogueBranchButton>().branch_choice = dt.branches[branch_choice].sections[0].responses[choice].next_branch_id;
        op1.GetComponent<DialogueBranchButton>().is_pressed = !op1.GetComponent<DialogueBranchButton>().is_pressed;

        if (!dt.branches[branch_choice].sections[0].responses[choice].end_on_response)
        {
            updateDialogue(op1.GetComponent<DialogueBranchButton>().branch_choice);
        }
        else if (choice > dt.branches.Length)
        {
            print("BEYOND ARRAY");
            hideDialogue();
        }
        else
        {
            hideDialogue();
        }

        //branch_choice = op1.GetComponent<DialogueBranchButton>().branch_choice;
    }

    void op2ButtonPress()
    {
        choice = op2.GetComponent<DialogueBranchButton>().choice;
        op2.GetComponent<DialogueBranchButton>().branch_choice = dt.branches[branch_choice].sections[0].responses[choice].next_branch_id;
        op2.GetComponent<DialogueBranchButton>().is_pressed = !op2.GetComponent<DialogueBranchButton>().is_pressed;


        if (!dt.branches[branch_choice].sections[0].responses[choice].end_on_response)
        {
            updateDialogue(op2.GetComponent<DialogueBranchButton>().branch_choice);
        }

        else
        {
            hideDialogue();
        }
        
    }

}


