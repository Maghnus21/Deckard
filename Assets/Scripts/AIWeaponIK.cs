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
    public Transform target_transform;
    public Transform aim_transform;

    public Vector3 target_offset = new Vector3(0f, 1f, 0f);

    public int iterations = 10;
    [Range(0, 1)]
    public float weight = 1f;

    public float angle_limit = 90f;
    public float distance_limit = 2f;


    public HumanBone[] human_bones;
    Transform[] bone_transforms;

    // Start is called before the first frame update
    void Start()
    {
        Animator animator = GetComponent<Animator>();
        bone_transforms = new Transform[human_bones.Length];
        for(int i = 0; i < bone_transforms.Length; i++)
        {
            bone_transforms[i] = animator.GetBoneTransform(human_bones[i].bone);
        }
    }

    
    Vector3 GetTargetPosition()
    {
        Vector3 target_direction = (target_transform.position + target_offset) - aim_transform.position;
        Vector3 aim_direction = aim_transform.forward;
        float blend_out = 0f;

        float target_angle = Vector3.Angle(target_direction, aim_direction);
        if(target_angle > angle_limit)
        {
            blend_out += (target_angle - angle_limit) / 50f;
        }

        Vector3 direction = Vector3.Slerp(target_direction, aim_direction, blend_out);
        return aim_transform.position + direction;
    }
    

    // Update is called once per frame
    void LateUpdate()
    {

        if(aim_transform == null)
        {
            return;
        }

        if(target_transform == null)
        {
            return;
        }



        Vector3 target_position = GetTargetPosition();

        for(int i = 0; i < iterations; i++)
        {
            for(int b = 0;b< bone_transforms.Length; b++)
            {
                Transform bone = bone_transforms[b];
                float bone_weight = human_bones[b].weight * weight;
                AimAtTarget(bone, target_position, bone_weight);
            }
        }

    }

    private void AimAtTarget(Transform bone, Vector3 target_position, float weight)
    {
        Vector3 aim_direction = aim_transform.forward;
        Vector3 target_direction = target_position - aim_transform.position;
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
