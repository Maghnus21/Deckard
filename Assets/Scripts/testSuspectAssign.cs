using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSuspectAssign : MonoBehaviour
{
    public DialogueScriptableObject[] dialogue_options;
    public GameObject[] suspects;
    int range;

    // Start is called before the first frame update
    void Awake()
    {
        Random.seed = (int)System.DateTime.Now.Ticks;

        

        
    }
}
