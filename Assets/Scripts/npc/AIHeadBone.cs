using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class AIHeadBone : MonoBehaviour
{
    public HumanBodyBones head_bone;


    public AIAgent agent;
    public Transform default_ik_target;
    public Transform new_ik_target;

    public Transform head_target_transform;
    public Transform head_transform;
    public Animator animator;


    public Vector3 target_offset = new Vector3(0f, 1f, 0f);
    Vector3 starting_pos;

    public float angle_limit = 80f;
    public float max_look_dis = 5f;

    public float head_move_seed = 3f;

    [Range(0, 1)]
    public float weight = 1f;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<AIAgent>();
        animator = GetComponent<Animator>();

        starting_pos = default_ik_target.transform.position;



        default_ik_target = agent.IK_gameobject_transform.transform;
        new_ik_target = agent.player_transform;

        head_target_transform = default_ik_target.transform;

        head_transform = animator.GetBoneTransform(head_bone);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(head_target_transform == null)
        {
            return;
        }
        if(head_transform == null)
        {
            return;
        }


        float distance = Vector3.Distance(transform.position, agent.player_transform.position);     
        
        if(distance <= 4f)
        {
            //float step = head_move_seed * Time.deltaTime;
            //default_ik_target.transform.position = Vector3.MoveTowards(default_ik_target.transform.position, agent.player_transform.position, step);

            head_target_transform.position = agent.player_transform.position;


        }
        else
        {
            //default_ik_target.transform.position = starting_pos;
            default_ik_target.position = starting_pos;
            head_target_transform.position = default_ik_target.position;

            
        }

        Vector3 target_position = GetTargetPosition();

        AimHeadAtTarget(head_transform, target_position, weight);

    }

    Vector3 GetTargetPosition()
    {
        Vector3 target_direction = (head_target_transform.position + target_offset) - head_transform.position;
        Vector3 head_direction = head_transform.forward;

        float blend_out = 0f;

        float target_angle = Vector3.Angle(target_direction, head_direction);

        if(target_angle > angle_limit)
        {

            blend_out += (target_angle - angle_limit) / 50f;
        }

        Vector3 direction = Vector3.Slerp(target_direction, head_direction, blend_out);
        return head_transform.position + direction;
    }

    public void AimHeadAtTarget(Transform head, Vector3 target_position, float weight)
    {
        Vector3 head_direction = head_transform.forward;
        Vector3 target_direction = target_position - head_transform.position;

        Quaternion face_towards = Quaternion.FromToRotation(head_direction, target_direction);  
        Quaternion blended_rotation = Quaternion.Slerp(Quaternion.identity, face_towards, weight);

        head.rotation = blended_rotation * head.rotation;
    }
}
