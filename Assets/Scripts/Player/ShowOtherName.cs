using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOtherName : MonoBehaviour
{
    void Start()
    {
        GetComponent<TextMesh>().text = gameObject.transform.parent.GetComponent<OtherPlayer>().name;
    }

}
