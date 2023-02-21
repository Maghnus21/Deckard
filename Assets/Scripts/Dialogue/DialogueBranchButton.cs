using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBranchButton : MonoBehaviour
{
    public bool is_pressed = false;
    public int branch_choice = 1;
    public int choice = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPress()
    {
        is_pressed = !is_pressed;
    }
}
