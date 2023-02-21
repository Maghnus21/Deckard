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
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        dt = GetComponent<DialogueTree>();

        dialogue_box = text.GetComponentInParent<Image>();

        dialogue_box.enabled = false;
        text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            showDialogue();
        }

        if(op1.GetComponent<DialogueBranchButton>().is_pressed)
        {
            int choice = op1.GetComponent<DialogueBranchButton>().choice;
            op1.GetComponent<DialogueBranchButton>().branch_choice = dt.branches[0].sections[0].responses[choice].next_branch_id;
            op2.GetComponent<DialogueBranchButton>().is_pressed = !op2.GetComponent<DialogueBranchButton>().is_pressed;

            updateDialogue(op1.GetComponent<DialogueBranchButton>().branch_choice);

        }
        else if (op2.GetComponent<DialogueBranchButton>().is_pressed)
        {
            int choice = op1.GetComponent<DialogueBranchButton>().choice;
            op2.GetComponent<DialogueBranchButton>().branch_choice = dt.branches[0].sections[0].responses[choice].next_branch_id;
            op2.GetComponent<DialogueBranchButton>().is_pressed = !op2.GetComponent<DialogueBranchButton>().is_pressed;



            updateDialogue(op2.GetComponent<DialogueBranchButton>().branch_choice);
        }
    }

    private void showDialogue()
    {
        dialogue_box.enabled = true;
        text.enabled = true;

        print(dt.branches[0].sections[0].dialogue);
        text.text = dt.branches[0].sections[0].dialogue;


        op1.GetComponentInChildren<TextMeshProUGUI>().text = dt.branches[0].sections[0].responses[0].response_dialogue;
        op2.GetComponentInChildren<TextMeshProUGUI>().text = dt.branches[0].sections[0].responses[1].response_dialogue;
    }

    void updateDialogue(int branch_choice)
    {
        i++;


        print(dt.branches[0].sections[0].dialogue);
        text.text = dt.branches[branch_choice].sections[0].dialogue;


        op1.GetComponentInChildren<TextMeshProUGUI>().text = dt.branches[branch_choice].sections[0].responses[0].response_dialogue;
        op2.GetComponentInChildren<TextMeshProUGUI>().text = dt.branches[branch_choice].sections[0].responses[1].response_dialogue;
    }

}


