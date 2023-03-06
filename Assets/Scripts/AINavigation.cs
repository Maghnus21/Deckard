using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AINavigation : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public Transform player_transform;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        navMeshAgent.destination = player_transform.position;

        animator.SetFloat("speed", navMeshAgent.velocity.magnitude);
    }
}
