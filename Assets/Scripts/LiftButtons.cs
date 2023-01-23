using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftButtons : MonoBehaviour
{
    public GameObject lift;
    public Vector3 lift_w_position;
    public float time = 5f;

    private Coroutine lift_animation;

    bool reached_des = true;

    private void Awake()
    {
        lift_w_position = new Vector3(lift.transform.position.x, lift_w_position.y, lift.transform.position.z);
    }

    public void LiftMovement()
    {
        if (!reached_des)
        {
            //lift_animation = StartCoroutine(liftMove(time));
        }
    }

    private IEnumerable liftMove(float time_to_take)
    {
        reached_des = true;

        float time = 0f;
        while(time < time_to_take)
        {
            lift.transform.position = Vector3.Lerp(lift.transform.position, lift_w_position, time);
            yield return null;
            time += Time.deltaTime * time_to_take;
        }
    }

}
