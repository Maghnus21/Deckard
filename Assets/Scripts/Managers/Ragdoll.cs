using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    Rigidbody[] rigidbodies;

    public Rigidbody impact_body_part;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();

        setRagdollState(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateRagdoll()
    {
        setRagdollState(false);
    }

    public void DeactivateRagdoll()
    {
        setRagdollState(true);
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
}
