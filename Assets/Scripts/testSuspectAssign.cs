using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSuspectAssign : MonoBehaviour
{
    public DialogueScriptableObject[] dialogue_options;
    public GameObject suspect;
    int range;

    // Start is called before the first frame update
    void Awake()
    {
        Random.seed = (int)System.DateTime.Now.Ticks;

        range = (int)Random.Range(0f, 5f);

        switch (range)
        {
            case 0:
                case 1:
                case 2: suspect.GetComponent<SusDialogue>().dialogue.npc_dialogue = dialogue_options[0];
                break;
                case 3:
                case 4:
                case 5: suspect.GetComponent<SusDialogue>().dialogue.npc_dialogue = dialogue_options[1];
                break;
        }
    }
}
