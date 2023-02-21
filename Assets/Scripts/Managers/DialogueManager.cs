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
    Image dialogue_box;



    void Awake()
    {
        dialogue_box = text.GetComponentInParent<Image>();

        dialogue_box.enabled = false;
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

    //  dialogue from susDialogue script
    /// <summary>
    /// ARRAY BASED DIALOGUE ONLY. sends data to DisplayNextSentence method to show dialogue on screen
    /// </summary>
    /// <param name="dialogue"></param>
    /// <param name="i"></param>
    public void StartDialogue(Dialogue dialogue, int i)
    {
        CancelInvoke();

        Debug.Log("Starting dialogue w/ " + dialogue.suspectInfo.name);

        //  clearing sentences queue of any data
        sentences.Clear();
        
        
        //  enqueues each sentence in the dialogue.sentences into an array
        foreach(string sentence in dialogue.suspectInfo.active_script.dialogue)
        {
            sentences.Enqueue(sentence);
        }
        

        //  receives string data from DialogueScriptableObject dialogue array stored in Dialogue and stores them in array array
        foreach(string k in array)
        {
            array = dialogue.suspectInfo.active_script.dialogue;
        }

        Debug.Log(i);   //  DEBUG USE
        DisplayNextSentence(i);
    }

    public void StartDialogueQueue(Dialogue dialogue)
    {
        CancelInvoke();

        //Debug.Log("Starting queue dialogue w/ " + dialogue.suspectInfo.name);

        //  clearing sentences queue of any data
        sentences.Clear();


        //  enqueues each sentence in the dialogue.sentences into an array
        foreach (string sentence in dialogue.dialogue.dialogue)
        {
            sentences.Enqueue(sentence);
        }

        //Debug.Log(i);   //  DEBUG USE
        DisplayNextSentence();
    }

    /// <summary>
    /// displays dialogue on screen from queue
    /// </summary>
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            Invoke("CloseDialogueBox", 5f);
        }

        dialogue_box.enabled = true;
        text.enabled = true;

        string sentence = sentences.Dequeue();
        Debug.Log("ANSWER FROM QUEUE: " + sentence);
        text.text = sentence;

        //  string stored in array is now displayed on the text element
        /*
        Debug.Log("ANSWER FROM STRING ARRAY: " + array[i]);
        text.text = array[i];
        */

        //  closes dialogue box after 5 seconds as long as no new input is displayed
        Invoke("CloseDialogueBox", 5f);
    }

    /// <summary>
    /// displays dialogue on screen from array
    /// </summary>
    /// <param name="i"></param>
    public void DisplayNextSentence(int i)
    {
        dialogue_box.enabled = true;
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

        //  string stored in array is now displayed on the text element
        Debug.Log("ANSWER FROM STRING ARRAY: " + array[i]);
        text.text = array[i];

        //  closes dialogue box after 5 seconds as long as no new input is displayed
        Invoke("CloseDialogueBox", 5f);
    }


    void EndDialogue()
    {
        Debug.Log("ENDED CONVERSATION");
    }

    void CloseDialogueBox()
    {
        dialogue_box.enabled = false;
        text.enabled = false;
    }
}
