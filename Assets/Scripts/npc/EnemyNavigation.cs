using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    public NavMeshAgent agent;
    public LayerMask layerMask;
    public float radius = 3f;
    public Light light;


    void Start()
    {
           
    }


    // Update is called once per frame
    void Update()
    {
        if(Physics.CheckSphere(this.transform.position, radius, layerMask))
        {
            Collider[] player = Physics.OverlapSphere(gameObject.transform.position, radius, layerMask);
            agent.SetDestination(player[0].transform.position);
            light.color = Color.red;
        }
        else
        {
            light.color = Color.green;
        }
    }
}
