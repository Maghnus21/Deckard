using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public GameObject bulllet_hole;

    void Start()
    {
        Destroy(this.gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        RaycastHit hit;

        if(Physics.Raycast(this.gameObject.transform.position, this.gameObject.transform.forward, out hit, 3f))
        {
            GameObject new_bullet_hole = Instantiate(bulllet_hole, hit.point + hit.normal * 0.001f, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(new_bullet_hole, 5);
        }
    }


}
