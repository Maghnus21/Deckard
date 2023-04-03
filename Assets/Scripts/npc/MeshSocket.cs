using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshSocket : MonoBehaviour
{

    public MeshSockets.SocketID socketID;

    public Transform attach_point;

    // Start is called before the first frame update
    void Start()
    {
        attach_point = transform.GetChild(0);
    }

    public void Attach(Transform object_transform)
    {
        object_transform.SetParent(attach_point, false);
    }
    
}
