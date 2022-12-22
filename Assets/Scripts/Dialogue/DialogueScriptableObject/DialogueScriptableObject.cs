using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue")]
public class DialogueScriptableObject : ScriptableObject
{
    public int array_size = 0;

    public string[] dialogue = {null};
}
