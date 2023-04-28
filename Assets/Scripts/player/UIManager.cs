using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI console_text;
    public TextMeshProUGUI medipen;

    public Button restart_button;

    private void Awake()
    {
        console_text.enabled = false;
    }

    private void Start()
    {
        
    }

    public void DisplayPickupItemText(Item item)
    {
        StopAllCoroutines();
        StartCoroutine(DisplayConsoleText("picked_up: [" + item.item_name + "]", 3f));
        //console_text.gameObject.SetActive(true);
    }
    public void DisplayPickupItemText(string text)
    {
        StopAllCoroutines();
        //console_text.gameObject.SetActive(true);

        StartCoroutine(DisplayConsoleText(text, 3f));
    }

    public void DisplayPlainText(string text)
    {
        StopAllCoroutines();

        StartCoroutine(DisplayConsoleText(text, 3f));
    }

    IEnumerator DisplayConsoleText(string text, float time)
    {
        console_text.enabled = true;
        console_text.text = text;

        yield return new WaitForSeconds(time);

        console_text.enabled = false;

        
    }

    public void UpdateMedipenDisplay(string text)
    {
        medipen.text = text;
    }

    public void EnableRestart(bool set_on)
    {
        restart_button.gameObject.SetActive(set_on);
    }

}
