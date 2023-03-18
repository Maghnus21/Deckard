using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshSocket : MonoBehaviour
{
    public HumanBodyBones bone;


    public Vector3 offset;
    public Vector3 rotation;


    public Transform attach_point;

    // Start is called before the first frame update
    void Start()
    {
        Animator animator = GetComponentInParent<Animator>();
        attach_point = new GameObject("socket").transform;
        attach_point.SetParent(animator.GetBoneTransform(bone));
        attach_point.localPosition = offset;
        attach_point.localRotation = Quaternion.Euler(rotation);

        GetComponentInParent<AIWeaponIK>().SetAimTransform(attach_point);
    }

    public void Attach(Transform object_transform)
    {
        object_transform.SetParent(attach_point, false);
    }
    
}
