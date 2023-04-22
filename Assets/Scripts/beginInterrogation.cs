using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beginInterrogation : MonoBehaviour
{

    public GameObject kit;
    public GameObject suspect;

    RaycastHit hit;
    Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        kit.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if(Physics.Raycast(ray, out hit, 3))
        {

            if(Input.GetKeyDown(KeyCode.F) && hit.collider.gameObject.GetComponentInParent<AIAgent>() && hit.collider.gameObject.GetComponentInParent<AIAgent>().interrogation_dialogue_tree != null)
            {
                print("BEGUN INTERROGATION");

                suspect = hit.collider.GetComponentInParent<AIAgent>().gameObject;
                kit.GetComponent<VKKit>().suspect = suspect;
            }
        }
    }
}
