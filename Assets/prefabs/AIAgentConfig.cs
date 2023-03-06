using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AIAgentConfig : ScriptableObject
{
    public float maxTime = 1f;
    public float maxDistance = 1f;
    public float impact_force = 10f;
    public float max_los_distance = 5f;
}
