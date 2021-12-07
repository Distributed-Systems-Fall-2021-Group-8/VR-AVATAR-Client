using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOwnName : MonoBehaviour
{

    void Start()
    {
        GetComponent<TextMesh>().text = OwnData.name;
    }

}
