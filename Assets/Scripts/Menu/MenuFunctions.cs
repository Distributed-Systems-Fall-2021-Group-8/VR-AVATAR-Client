using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour
{
    
    public void toGame()
    {
        SceneManager.LoadScene("GameRoom", LoadSceneMode.Single);
    }

    public void exit()
    {
        Application.Quit();
    }

    public void changeName(string newName)
    {
        OwnData.name = newName;
    }

    public void changeAddress(string newAddress)
    {
        ConnectionData.address = newAddress;
    }

    public void changePort(string newPort)
    {
        ConnectionData.port = newPort;
    }

}
