using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

// please refernce this video for improving the animation rigging: https://www.youtube.com/watch?v=Q56quIB2sOg&list=PLyBYG1JGBcd009lc1ZfX9ZN5oVUW7AFVy&index=5



[System.Serializable]
public class HumanBone
{
    public HumanBodyBones bone;
    public float weight = 1f;
}


public class AIWeaponIK : MonoBehaviour
{
    public Transform target_transform;      //  ik point
    public Transform aim_transform;         // gun barrel
    public Transform bone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void LateUpdate()
    {
        Vector3 target_position = target_transform.position;
        AimAtTarget(bone, target_position);
    }

    private void AimAtTarget(Transform bone, Vector3 target_position)
    {
        Vector3 aim_direction = aim_transform.forward;
        Vector3 target_direction = target_position  -aim_transform.position; 
        Quaternion aim_towards = Quaternion.FromToRotation(aim_direction, target_direction);
        bone.rotation = aim_towards * bone.rotation;
    }
}
