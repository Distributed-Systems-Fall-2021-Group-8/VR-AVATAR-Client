using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatFunctions : MonoBehaviour
{
    public string chatMessage;
    public InputField chatInput;
    void Start()
    {
        chatMessage = "";
    }

    public void changeChat(string newChatMessage)
    {
        chatMessage = newChatMessage;
    }

    public void sendMessage()
    {
        //ask ConnectionManager to emit the chatMessage with OwnData.name
        Debug.Log(chatMessage);
        chatMessage = "";
        chatInput.text = "";
    }
}
