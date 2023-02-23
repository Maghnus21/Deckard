using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosiveHealth : MonoBehaviour
{
    Health health;
    public GameObject explosion;
    float melting_health;

    public bool created_explosion;
    bool coroutine_started = false;

    private void Awake()
    {
        health = GetComponent<Health>();
        melting_health = health.health / 2;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health.health <= melting_health)
        {
            coroutine_started = true;
            StartCoroutine(explosion_countdown());
        }


        if(health.health <= 0 && !created_explosion)
        {
            StopCoroutine(explosion_countdown());

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


    IEnumerator explosion_countdown()
    {
        
        yield return new WaitForSeconds(1f);
        health.health -= .001f;
    }
}
