using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosiveHealth : MonoBehaviour
{
    Health health;
    public GameObject explosion;

    public bool created_explosion;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health.health <= 0 && !created_explosion)
        {
            GameObject new_explosion = Instantiate(explosion, transform.position, transform.rotation);
            new_explosion.GetComponent<explode>().Explode();

            created_explosion = true;

            Destroy(new_explosion, 1f);
            Destroy(this.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(Color.red.r, Color.red.g, Color.red.b, 0.3f);
        Gizmos.DrawSphere(transform.position, explosion.GetComponent<explode>().explosion_radius);
    }
}
