using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterrogationDialogueTree : MonoBehaviour
{
    public DialogueBranch[] branches;
}

[System.Serializable]
public class InterrogationDialogueBranch
{
    public string branch_name;
    public int branch_id;
    //public bool end_on_final;

    public InterrogationDialogueSection[] sections;
}

[System.Serializable]
public class InterrogationDialogueSection
{
    [TextArea]
    public string dialogue;

    public InterrogationDialogueResponse[] responses;
}

[System.Serializable]
public class InterrogationDialogueResponse
{
    //  ensures player can exit dialogue when conversation is completed
    public bool end_on_response = false;
    public bool initialize_interrogation = false;
    public bool turn_hostile = false;


    public int next_branch_id;
    
    [TextArea]
    public string response_dialogue;
}
