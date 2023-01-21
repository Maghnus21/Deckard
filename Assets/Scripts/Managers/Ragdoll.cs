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

    public void ApplyForce(Vector3 force)
    {
        impact_body_part.AddForce(force, ForceMode.VelocityChange);
    }
}
