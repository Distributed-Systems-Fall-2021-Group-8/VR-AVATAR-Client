using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class ConnectionManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject socketIOObject;
    public GameObject player;
    public GameObject otherPlayerPrefab;
    string id;
    Dictionary<string, OtherPlayer> otherPlayers;
    SocketIOComponent socket;
    void Start()
    {
        otherPlayers = new Dictionary<string, OtherPlayer>();
        socket = socketIOObject.GetComponent<SocketIOComponent>();
        socket.On("open", OnSocketOpen);
        socket.On("positionsChange", OnPositionsChange);
        socket.On("playerJoin", OnPlayerJoin);
        socket.On("playerLeave", OnPlayerLeave);
    }


    public void OnSocketOpen(SocketIOEvent ev)
    {
        Dictionary<string, string> data = new Dictionary<string, string>();
        data["name"] = OwnData.name;
        data["x"] = "0";
        data["y"] = "0";
        socket.Emit("playerJoin", new JSONObject(data));
        Debug.Log("Connected with socket id " + socket.sid);
        id = socket.sid;
    }

    public void OnPositionsChange(SocketIOEvent ev)
    {
        for (int i = 0; i < ev.data["playersArray"].Count; i += 1)
        {
            OtherPlayer playerToUpdate = otherPlayers[ev.data["playersArray"][i]["id"].ToString()];
            playerToUpdate.x = float.Parse(ev.data["playersArray"][i]["x"].ToString().Substring(1, ev.data["playersArray"][i]["x"].ToString().Length - 2));
            playerToUpdate.y = float.Parse(ev.data["playersArray"][i]["y"].ToString().Substring(1, ev.data["playersArray"][i]["y"].ToString().Length - 2));          
        }

    }

    public void OnPlayerJoin(SocketIOEvent ev)
    {// delete 1st ! to test solo
        if (!ev.data["id"].ToString().Substring(1, ev.data["id"].ToString().Length - 2).Equals(id) && !otherPlayers.ContainsKey(ev.data["id"].ToString()))
        {
            GameObject newPlayer = (GameObject) Instantiate(otherPlayerPrefab);
            OtherPlayer newPlayerData = newPlayer.GetComponent<OtherPlayer>();
            newPlayerData.name = ev.data["name"].ToString().Substring(1, ev.data["name"].ToString().Length-2);
            newPlayerData.id= ev.data["id"].ToString();
            newPlayerData.x = float.Parse(ev.data["x"].ToString().Substring(1, ev.data["x"].ToString().Length-2));
            newPlayerData.y = float.Parse(ev.data["y"].ToString().Substring(1, ev.data["y"].ToString().Length - 2));
            otherPlayers.Add(ev.data["id"].ToString(), newPlayerData);
        }
    }

    public void OnPlayerLeave(SocketIOEvent ev)
    {
        Destroy(otherPlayers[ev.data["playerID"].ToString()].gameObject);
        otherPlayers.Remove(ev.data["playerID"].ToString());
    }

    //Every 30 frames send position data to server.
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
        data["y"] = player.transform.position.y.ToString();
        socket.Emit("positionChange", new JSONObject(data));
    }

    public void disconnect()
    {
        socket.Emit("disconnect");
    }

}
