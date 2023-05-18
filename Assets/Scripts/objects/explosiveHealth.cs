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
        if(health.health <= melting_health && !coroutine_started)
        {
            StartCoroutine(explosion_countdown());
            coroutine_started = true;
        }


        if(health.health <= 0f && !created_explosion)
        {

            int layer_mask = LayerMask.NameToLayer("Ignore Raycast");
            this.gameObject.layer = layer_mask;

            StopCoroutine(explosion_countdown());

            this.gameObject.SetActive(false);
            Destroy(gameObject, 3f);

            Instantiate(explosion, transform.position, transform.rotation).GetComponent<explode>().Explode();
            created_explosion = true;
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(Color.red.r, Color.red.g, Color.red.b, 0.3f);
        Gizmos.DrawSphere(transform.position, explosion.GetComponent<explode>().explosion_radius);
    }


    IEnumerator explosion_countdown()
    {
        while (true)
        {
            yield return new WaitForSeconds(.5f);
            health.health -= .3f;
        }
        
    }

    void detonate()
    {
        health.health = 0;
    }
}
