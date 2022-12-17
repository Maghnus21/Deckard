using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// 
/// This code contains code to use a queue-based dialogue system as to save time in future. Array based code will be seperated into seperate functions to allow NPCs with
/// small amounts of dialogue, eg 1 line, to display dialogue on the screen, without the need to define the array size constantly
/// 
/// </summary>


public class DialogueManager : MonoBehaviour
{
    //  dialogue sentences stored in queue to be displayed on ui
    public Queue<string> sentences;

    //  dialogue sentences stored in string array to be displayed on ui
    public string[] array = new string[9];

    //  reference to ui element
    public TextMeshProUGUI text;



    void Awake()
    {
        text.GetComponentInParent<Image>().enabled = false;
        text.enabled = false;
    }


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
        text.GetComponentInParent<Image>().enabled = true;
        text.enabled = true;

        // if there are no sentences in sentences, exits out of loop and
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        Debug.Log("ANSWER FROM QUEUE: " + sentence);
        //text.text = sentence;

        Debug.Log("ANSWER FROM STRING ARRAY: " + array[i]);
        text.text = array[i];

        Invoke("CloseDialogueBox", 5f);
    }


    void EndDialogue()
    {
        Debug.Log("ENDED CONVERSATION");
    }

    void CloseDialogueBox()
    {
        text.enabled = false;
    }
}
