using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthControl : EntityHealthControl
{
    public GameObject SpawnPoint;

    public override void OnDeath()
    {
        base.Start();
        gameObject.transform.position = SpawnPoint.transform.position;
    }
}
