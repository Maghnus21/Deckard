using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakObject : MonoBehaviour
{
    [SerializeField]public float health = -25f;
    // Start is called before the first frame update
    void Start()
    {
        if(health <= 0f)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<BulletBehaviour>() == true && health > 1f)
        {
            collision.gameObject.GetComponent<BulletBehaviour>().damage -= health;
        }
    }
}
