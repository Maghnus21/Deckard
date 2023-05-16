using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalScavDeath : MonoBehaviour
{
    public List<Health> entities = new List<Health>();

    public AIAgent agent;
    public DialogueTreeScriptableObject tree;


    private void Awake()
    {
        foreach(Health health in GetComponentsInChildren<Health>())
            entities.Add(health);
    }


    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(CheckEntityList());
    }

    // Update is called once per frame
    void Update()
    {
        entities.ForEach(health =>
        {
            if (health.health <= 0f)
                entities.Remove(health);
        });

        if (entities.Count == 0)
        {
            agent.dialogue_tree = tree;
            this.enabled = false;
        }
    }

    IEnumerator CheckEntityList()
    {
        while (true)
        {
            

            

            yield return new WaitForSeconds(1f);
        }
            
    }
}
