using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSuspectAssign : MonoBehaviour
{
    public GameObject[] suspects;
    int range = 64;
    float ran_num;

    // Start is called before the first frame update
    void Awake()
    {
        Random.seed = (int)System.DateTime.Now.Ticks;

        ran_num = Random.Range(0, range);





        suspects[0].GetComponent<SusDialogue>().dialogue.suspectInfo.active_script = suspects[0].GetComponent<SusDialogue>().dialogue.suspectInfo.dialogue_scritps[0];

    }
}
