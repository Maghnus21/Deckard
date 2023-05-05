using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTarget : MonoBehaviour
{
    public AIAgent suspect;

    public List<InterrogationDialogueTreeScriptableObject> interrogation_tree_scripts;

    // Start is called before the first frame update
    void Start()
    {
        //Random.InitState(1);
        Random.InitState((int)System.DateTime.Now.Ticks);

        int rand = Random.Range(0, 100);

        if (rand <= 50) suspect.interrogation_dialogue_tree = interrogation_tree_scripts[0];        //  real human
        else suspect.interrogation_dialogue_tree = interrogation_tree_scripts[1];                   //  fake human
    }
}
