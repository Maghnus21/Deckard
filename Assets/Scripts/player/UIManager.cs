using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI console_text;

    private void Awake()
    {
        
    }

    private void Start()
    {
        console_text.enabled = false;
    }

    public void DisplayPickupItemText(string text)
    {
        //StopAllCoroutines();

        console_text.enabled = true;

        console_text.text = text;

        
    }

    IEnumerator ConsoleTextDisplay()
    {
        

        yield return new WaitForSeconds(3f);

        console_text.enabled = false;
    }
}
