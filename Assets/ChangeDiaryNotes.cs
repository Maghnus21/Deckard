using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDiaryNotes : MonoBehaviour
{
    public AIAgent user;
    public TalkableEntity entity;

    public DialogueTreeScriptableObject real, fake;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (user.interrogation_dialogue_tree != null)
            if (!user.interrogation_dialogue_tree.is_real_human)
                entity.phone_dialogue = fake;
            else
                entity.phone_dialogue = real;

        this.enabled = false;
    }
}
