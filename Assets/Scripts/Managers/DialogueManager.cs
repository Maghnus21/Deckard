using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public Queue<string> sentences;

    //  dialogue sentences stored in string array to be displayed on ui
    public string[] array = new string[12];

    //  reference to ui element
    public TextMeshProUGUI text;



    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartDialogue(Dialogue dialogue, int i)
    {
        Debug.Log("Starting dialogue w/ " + dialogue.name);

        //  clearing sentences queue of any data
        sentences.Clear();
        
        //  enqueues each sentence in the dialogue.sentences into an array
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        // stores each string from the dialogue.sentences into array
        foreach(string k in array)
        {
            array = dialogue.sentences;
        }

        Debug.Log(i);   //  DEBUG USE
        DisplayNextSentence(i);
    }


    public void DisplayNextSentence(int i)
    {
        // if there are no sentences in sentences, exits out of loop and
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
        //text.text = sentence;

        Debug.Log(array[i]);
        text.text = array[i];
    }


    void EndDialogue()
    {
        Debug.Log("ENDED CONVERSATION");
    }
}
