using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue Tree", menuName = "Dialogue Tree")]
public class DialogueTreeScriptableObject : ScriptableObject
{
    public DialogueBranch[] branches;
}

[System.Serializable]
public class DialogueBranch
{
    public string branch_name;
    public int branch_id;
    //public bool end_on_final;

    public DialogueSection[] sections;
}

[System.Serializable]
public class DialogueSection
{
    [TextArea]
    public string dialogue;

    public DialogueResponse[] responses;
}

[System.Serializable]
public class DialogueResponse
{
    //  ensures player can exit dialogue when conversation is completed
    public bool end_on_response = false;
    public bool initialize_interrogation = false;
    public bool turn_hostile = false;

    public int next_branch_id;
    
    [TextArea]
    public string response_dialogue;
}
