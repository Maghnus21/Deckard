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
    [Range(0f, 1f)]
    public float weight = 1f;
}


public class AIWeaponIK : MonoBehaviour
{
    public Transform target_transform;      //  ik point
    public Transform aim_transform;         // gun barrel
    public Vector3 target_offset;

    int iterations = 10;
    [Range(0f, 1f)]
    public float weight = 1f;

    public float angle_limit = 90f;
    public float distance_limit = 2f;
    public HumanBone[] human_bones;
    Transform[] bone_transforms;

    // Start is called before the first frame update
    void Start()
    {
        if (aim_transform == null) return;

        if(target_transform == null) return;


        Animator animator = GetComponent<Animator>();
        bone_transforms = new Transform[human_bones.Length];
        for(int i = 0; i <bone_transforms.Length; i++)
            bone_transforms[i] = animator.GetBoneTransform(human_bones[i].bone);
    }

    Vector3 GetTargetPosition()
    {
        Vector3 target_direction = (target_transform.position + target_offset)- aim_transform.position;
        Vector3 aim_direction = aim_transform.forward;
        float blend_out = 0f;

        float target_angle = Vector3.Angle(target_direction, aim_direction);
        if (target_angle > angle_limit)
            blend_out += (target_angle - angle_limit) / 50f;

        float target_distance = target_direction.magnitude;
        if (target_distance < distance_limit)
            blend_out += distance_limit - target_distance;

        Vector3 direction = Vector3.Slerp(target_direction, aim_direction, blend_out);
        return aim_transform.position + direction;
    }

    private void LateUpdate()
    {
        Vector3 target_position = GetTargetPosition();

        for(int i = 0; i < iterations; i++)
            for(int b=0;b<bone_transforms.Length; b++)
            {
                Transform bone = bone_transforms[b];
                AimAtTarget(bone, target_position);
            }

    }

    private void AimAtTarget(Transform bone, Vector3 target_position)
    {
        Vector3 aim_direction = aim_transform.forward;
        Vector3 target_direction = target_position  -aim_transform.position; 
        Quaternion aim_towards = Quaternion.FromToRotation(aim_direction, target_direction);
        Quaternion blended_rotation = Quaternion.Slerp(Quaternion.identity, aim_towards, weight);
        
        bone.rotation = blended_rotation * bone.rotation;
    }

    public void SetTargetTransform(Transform target)
    {
        target_transform = target;
    }

    public void SetAimTransform(Transform aim)
    {
        aim_transform = aim;
    }
}
