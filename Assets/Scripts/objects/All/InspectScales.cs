using UnityEngine;

public class InspectScales : MonoBehaviour
{
    // This is a basic script only containing Inspect window scales for weapons. Data is stored on original gameObject and read by the inspect window script, then applied to instantiated clone
    // Both univeral scaling and axis-specific scaling included
    // Default scale set to 80f

    public float x_scale = 80f, y_scale = 80f, z_scale = 80f;

    [Tooltip("This is used for X, Y, and Z scaling")]
    public float universal = 80f;
}
