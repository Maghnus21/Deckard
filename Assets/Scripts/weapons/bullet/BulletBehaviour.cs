using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public GameObject bulllet_hole;

    void Start()
    {
        Destroy(this.gameObject, 1);

        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
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
            // code below creates bullet holes on wall. gameobjects say facing the z axis, bullet holes appear on any collider and collision with realtime csg objects not working correctly
            // uncomment later
            /*
            GameObject new_bullet_hole = Instantiate(bulllet_hole, hit.point + hit.normal * 0.001f, Quaternion.identity);
            Destroy(new_bullet_hole, 5);*/

            Destroy(this.gameObject);
            
        }
    }


}
