using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ragdoll : MonoBehaviour
{
    Rigidbody[] rigidbodies;
    Animator animator;
    NavMeshAgent nma;
    AINavigation nav;

    public Rigidbody impact_body_part;

    public bool trigger_rd = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();

        setRagdollState(true);

        animator = gameObject.GetComponent<Animator>();
        nma = gameObject.GetComponent<NavMeshAgent>();
        nav = gameObject.GetComponent<AINavigation>();

    }

    // Update is called once per frame
    void Update()
    {
        if (trigger_rd)
        {
            ActivateRagdoll();
        }
    }

    public void ActivateRagdoll()
    {
        animator.enabled = false;
        nma.enabled = false;
        nav.enabled = false;


        setRagdollState(false);


    }

    public void DeactivateRagdoll()
    {
        setRagdollState(true);

        this.gameObject.GetComponent<AINavigation>().enabled = false;
    }

    void setRagdollState(bool state)
    {
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.isKinematic = state;
        }
    }

    /// <summary>
    /// Applies force to ragdoll rigidbody gameObject from incoming direction
    /// </summary>
    /// <param name="force"></param>
    /// <param name="force_mode_type">assign as true to include gameObject mass into physics, assign as false to ignore gameObject mass</param>
    public void ApplyForce(Vector3 force, bool force_mode_type)
    {
        if (force_mode_type)
        {
            impact_body_part.AddForce(force, ForceMode.Impulse);
        }
        if (!force_mode_type)
        {
            impact_body_part.AddForce(force, ForceMode.VelocityChange);
        }
        
    }

    public void AddExplosiveForcePoint(Vector3 det_pos, float exp_force, float exp_radius, float exp_upforce, bool force_mode_type)
    {
        Collider[] exp_col = Physics.OverlapSphere(det_pos, 5f); ;

        foreach(Collider collider in exp_col)
        {
            Rigidbody rigidbody = collider.GetComponent<Rigidbody>();

            if(rigidbody != null)
            {
                if(force_mode_type) rigidbody.AddExplosionForce(exp_force, det_pos, exp_radius, exp_upforce, ForceMode.Impulse);

                if (!force_mode_type) rigidbody.AddExplosionForce(exp_force, det_pos, exp_radius, exp_upforce, ForceMode.VelocityChange);
            }
        }       
    }
}
