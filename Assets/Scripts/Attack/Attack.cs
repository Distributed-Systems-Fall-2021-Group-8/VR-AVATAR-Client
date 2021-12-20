using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int Damage = 1;
    public bool DestroyedAfterHit = true;

    public string AttackTarget = "AllLocal";

    private void OnTriggerEnter2D(Collider2D other)
    {
        // IMPLEMENT: In case of "OtherPlayer", send the attack for them to handle
        if (other.tag == AttackTarget
            || (AttackTarget == "All" && (other.tag == "Player" || other.tag == "OtherPlayer" || other.tag == "Enemy"))
            || (AttackTarget == "AllLocal" && (other.tag == "Player" || other.tag == "Enemy"))
            || (AttackTarget == "NotPlayer" && (other.tag == "OtherPlayer" || other.tag == "Enemy")))
        {
            EntityHealthControl EHC = other.GetComponent<EntityHealthControl>();
            if (EHC)
            {
                EHC.TakeDamage(Damage);
                if (DestroyedAfterHit)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
