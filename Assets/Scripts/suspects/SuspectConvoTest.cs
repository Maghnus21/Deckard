using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SuspectConvoTest : MonoBehaviour
{
    public TextMeshProUGUI dialogue;
    public int[] choice = new int[3] {0, 0, 0}; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(choice[0] != 0)
        {
            switch (choice[0])
            {
                case 1: dialogue.text = "button1";
                    break;
                case 2: dialogue.text = "button2";
                    break;
                case 3: dialogue.text = "button3";
                    break;
            }
        }
        if (choice[1] != 0)
        {
            switch (choice[1])
            {
                case 1:
                    dialogue.text = "button1";
                    break;
                case 2:
                    dialogue.text = "button2";
                    break;
                case 3:
                    dialogue.text = "button3";
                    break;
            }
        }
        if (choice[2] != 0)
        {
            switch (choice[2])
            {
                case 1:
                    dialogue.text = "button1";
                    break;
                case 2:
                    dialogue.text = "button2";
                    break;
                case 3:
                    dialogue.text = "button3";
                    break;
            }
        }

    }
}
