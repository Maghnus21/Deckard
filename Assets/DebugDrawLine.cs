using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDrawLine : MonoBehaviour
{
    public Transform barrel_end_pos;

    private void OnDrawGizmos()
    {
        Debug.DrawLine(barrel_end_pos.position, barrel_end_pos.position + barrel_end_pos.forward, Color.green);
    }
}
