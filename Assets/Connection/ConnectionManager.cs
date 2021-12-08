using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
public class ConnectionManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject go;
    SocketIOComponent socket;
    void Start()
    {
        socket = go.GetComponent<SocketIOComponent>();
        socket.On("open", OnSocketOpen);
        socket.On("positionsChange", OnPositionChange);
    }

    public void OnSocketOpen(SocketIOEvent ev)
    {
        Dictionary<string, string> data = new Dictionary<string, string>();
        data["name"] = "example";
        data["x"] = "0";
        data["y"] = "0";
        socket.Emit("initialize", new JSONObject(data));
        Debug.Log("updated socket id " + socket.sid);
    }

    public void OnPositionChange(SocketIOEvent ev)
    {
        Debug.Log(ev.data["playersArray"]);
        Debug.Log(ev.data["playersArray"][0]["name"]);
    }

}
