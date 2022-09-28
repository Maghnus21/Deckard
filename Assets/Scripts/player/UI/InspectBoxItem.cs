using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InspectBoxItem : MonoBehaviour
{
    public float pickup_dis = 3f;


    public Transform ui_inspect_spawn;
    public Image inspect_box;
    public Image pickup_image;

    GameObject item_inspect;

    bool is_inspecting = false;

    InspectScales scales;


    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        inspect_box.enabled = false;
        pickup_image.enabled = false;
        inspect_box.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, pickup_dis) && hit.collider.tag == "Interactable")
        {

            pickup_image.enabled = true;

            if (Input.GetKeyDown(KeyCode.F))
            {
                inspect_box.enabled = true;
                inspect_box.GetComponentInChildren<TextMeshProUGUI>().enabled = true;



                Destroy(hit.collider.gameObject);

                // ERROR CHECK - if interactable gameObject does NOT include WeaponInspectScale script, adds automatically with default scaling (80 on all axis)
                if (hit.collider.gameObject.GetComponent<InspectScales>() == true)
                {
                    scales = hit.collider.gameObject.GetComponent<InspectScales>();
                }
                else
                {
                    hit.collider.gameObject.AddComponent<InspectScales>();
                }


                // removes existing gameobject and replaces with new gameobject
                if (is_inspecting == true)
                {
                    Destroy(item_inspect.gameObject);

                    CreateGameObject(scales);
                }
                else
                {
                    is_inspecting = true;

                    CreateGameObject(scales);
                }




                // checks if the gameObject child count is greater than 0. if so, children are given layer mask value of UI
                if (item_inspect.transform.childCount > 0)
                {
                    foreach (Transform child in item_inspect.transform)
                    {
                        if (child == null)
                        {
                            continue;
                        }
                        child.transform.gameObject.layer = LayerMask.NameToLayer("UI");
                    }

                }
                else
                {
                    item_inspect.layer = LayerMask.NameToLayer("UI");
                }

                item_inspect.AddComponent<InspectRotate>();



                Invoke("InspectBoxClose", 10f);
            }
        }
        else
        {
            pickup_image.enabled = false;
        }
        
    }

    void InspectBoxClose()
    {
        inspect_box.enabled = false;
        inspect_box.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
        is_inspecting = false;

        Destroy(item_inspect.gameObject);
    }

    void CreateGameObject(InspectScales scales)
    {
        item_inspect = Instantiate(hit.collider.gameObject, ui_inspect_spawn);
        item_inspect.gameObject.GetComponent<Rigidbody>().isKinematic = true;

        item_inspect.transform.position = ui_inspect_spawn.transform.position;
        item_inspect.transform.localScale = new Vector3(scales.universal, scales.universal, scales.universal);

        // [ADDITION] - need reference to textMesh to update window text
    }
}
