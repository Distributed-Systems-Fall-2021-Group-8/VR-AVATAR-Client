using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctionality : MonoBehaviour
{
    public GameObject connectionManager;
    public void exitGameRoom()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        connectionManager.GetComponent<ConnectionManager>().disconnect();
    }
}
