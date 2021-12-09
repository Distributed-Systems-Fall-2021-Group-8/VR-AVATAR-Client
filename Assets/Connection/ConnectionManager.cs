using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
public class ConnectionManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject socketIOObject;
    public GameObject player;
    string id;
    SocketIOComponent socket;
    void Start()
    {
        socket = socketIOObject.GetComponent<SocketIOComponent>();
        socket.On("open", OnSocketOpen);
        socket.On("positionsChange", OnPositionsChange);
    }

    public void OnSocketOpen(SocketIOEvent ev)
    {
        Dictionary<string, string> data = new Dictionary<string, string>();
        data["name"] = OwnData.name;
        data["x"] = "0";
        data["y"] = "0";
        socket.Emit("initialize", new JSONObject(data));
        Debug.Log("Connected with socket id " + socket.sid);
        id = socket.sid;
    }

    public void OnPositionsChange(SocketIOEvent ev)
    {
        Debug.Log(ev.data["playersArray"]);
        Debug.Log(ev.data["playersArray"][0]["name"]);
        //update player positions
    }

    public int interval = 30;

    void FixedUpdate() 
    { 
        if (Time.frameCount % interval == 0) {
            PositionChange();
         } 
    }

    void PositionChange()
    {
        Dictionary<string, string> data = new Dictionary<string, string>();
        data["x"] = player.transform.position.x.ToString();
        data["y"] = player.transform.position.x.ToString();
        socket.Emit("positionChange", new JSONObject(data));
    }

}
