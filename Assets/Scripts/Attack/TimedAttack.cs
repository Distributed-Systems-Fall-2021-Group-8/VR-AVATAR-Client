using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedAttack : Attack
{
    public float MaxLifeTime = 1f;

    private void Start()
    {
        Destroy(gameObject, MaxLifeTime);
    }
}
