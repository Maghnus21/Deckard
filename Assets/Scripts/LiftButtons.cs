using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftButtons : MonoBehaviour
{
    public GameObject lift;
    public Vector3 lift_w_position;
    public float speed = 0.1f;

    private Coroutine lift_animation;

    bool reached_des = true;

    private void Awake()
    {
        lift_w_position = new Vector3(lift.transform.position.x, lift_w_position.y, lift.transform.position.z);
    }

    public void LiftMovement()
    {
        
        lift_animation = StartCoroutine(liftMove(lift_w_position, speed));
        
    }

    private IEnumerator liftMove(Vector3 target_pos, float speed)
    {
        reached_des = false;

        Vector3 start_pos = lift.transform.position;

        float time = 0f;
        while(time < speed)
        {
            lift.transform.position = Vector3.Lerp(start_pos, target_pos, time / speed);
            time += Time.deltaTime;
            yield return null;
        }
        lift.transform.position = target_pos;
    }

}
