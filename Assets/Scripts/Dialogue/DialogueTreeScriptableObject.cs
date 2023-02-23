using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue Tree SO", menuName = "Dialogue Tree SO")]
public class DialogueTreeDialogueTreeScriptableObject : ScriptableObject
{
    public DialogueBranch[] branches;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class DialogueBranchSO
{
    public string branch_name;
    public int branch_id;
    //public bool end_on_final;

    public DialogueSection[] sections;
}

[System.Serializable]
public class DialogueSectionSO
{
    [TextArea]
    public string dialogue;

    public DialogueResponse[] responses;
}

[System.Serializable]
public class DialogueResponseSO
{
    //  ensures player can exit dialogue when conversation is completed
    public bool end_on_response = false;
    public int next_branch_id;
    
    [TextArea]
    public string response_dialogue;
}
