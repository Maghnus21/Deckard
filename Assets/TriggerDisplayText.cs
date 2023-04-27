using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDisplayText : MonoBehaviour
{
    [TextArea]
    public string text;

    public bool display_text;

    public UIManager ui_man;

    // Start is called before the first frame update
    void Start()
    {
        ui_man = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (display_text)
        {
            ui_man.DisplayPlainText(text);

            Destroy(gameObject);
        }
            

    }
}
