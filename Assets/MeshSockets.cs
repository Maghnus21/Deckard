using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshSockets : MonoBehaviour
{
    public enum SocketID
    {
        Spine,
        RightHand
    }

    Dictionary<SocketID, MeshSocket> socket_map = new Dictionary<SocketID, MeshSocket>();

    // Start is called before the first frame update
    void Start()
    {
        MeshSocket[] sockets = GetComponentsInChildren<MeshSocket>();
        foreach (MeshSocket socket in sockets)
        {
            socket_map[socket.socketID] = socket;
        }
    }

    public void Attach(Transform object_transform, SocketID socket_id)
    {
        socket_map[socket_id].Attach(object_transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
