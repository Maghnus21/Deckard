using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Suspect", menuName = "Suspect")]
public class suspectInfoScriptableObject : ScriptableObject
{
    public string name;
    public string human_type;
    public GameObject suspect;

    public DialogueScriptableObject active_script;
    public DialogueScriptableObject[] dialogue_scritps;

}
