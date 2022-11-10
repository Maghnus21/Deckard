using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public GameObject bulllet_hole;
    public float damage = 50;

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
        // checks if game object has enemyhealth script and health is greater than 0, then will damage enemy
        if(collision.gameObject.GetComponent<enemyHealth>() == true && collision.gameObject.GetComponent<enemyHealth>().health > 0)
        {
            collision.gameObject.GetComponent<enemyHealth>().health -= damage;
        }

        
    }


}
