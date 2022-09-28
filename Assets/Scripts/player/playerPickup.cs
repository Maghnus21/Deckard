using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerPickup : MonoBehaviour
{
    float pickup_dis = 5f;

    public Canvas canvas;
    public GameObject pickup_text;
    public Transform item_spawn;

    TextMeshProUGUI textMesh;



    int layerMask;

    Ray ray;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        layerMask = ~LayerMask.GetMask("Player");
        textMesh = pickup_text.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(Camera.main.transform.position, transform.forward * pickup_dis, out hit) && hit.collider.tag == "Interactable" && Input.GetKeyDown(KeyCode.F))
        {
            Destroy(hit.transform.gameObject);

            GameObject gameObject = Instantiate(hit.transform.gameObject, item_spawn);
            

            textMesh.text = "Picked up " + hit.transform.gameObject.name;
        }
    }
}
