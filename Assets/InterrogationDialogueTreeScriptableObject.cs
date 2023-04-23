using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New interrogation dialogue", menuName = "Interrogation tree")]
public class InterrogationDialogueTreeScriptableObject : ScriptableObject
{
    public InterrogationDialogueBranch[] branches;

    public bool is_real_human = true;
    public DialogueTreeScriptableObject post_interro_ersatz_dialogue;

    public float reveal_human_type_level = 4;
    public float turn_hostile_level = 8;
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
    public bool turn_hostile = false;
    public float add_aggression;


    public int next_branch_id;

    [TextArea]
    public string response_dialogue;
}

