using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBranchButton : MonoBehaviour
{
    public branchDialogueManager branch_dialogue_manager;


    public bool is_pressed = false;
    public int branch_choice = 1;
    public int choice = 0;

    public void OnPress()
    {
        branch_dialogue_manager.UpdateConvo(branch_choice, choice);

        /*
        branch_dialogue_manager.branch_choice = branch_choice;
        branch_dialogue_manager.DisplayConvo();
        */
        print("Pressed button");
    }
}
