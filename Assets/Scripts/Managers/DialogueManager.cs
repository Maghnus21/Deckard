using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public Queue<string> sentences;

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

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        Debug.Log(i);
        DisplayNextSentence();
    }


    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
        text.text = sentence;
        
    }

    void EndDialogue()
    {
        Debug.Log("ENDED CONVERSATION");
    }
}
