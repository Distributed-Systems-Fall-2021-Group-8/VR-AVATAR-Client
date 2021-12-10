using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherPlayer : MonoBehaviour
{
    public float x;
    public float y;
    public string name;
    public string id;
    public float Speed = 10f;
    private Rigidbody2D Rb;
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    //Move towards destination point (x,y).
    void Move()
    {
        if(x != gameObject.transform.position.x && y != gameObject.transform.position.y)
        {
            Vector2 movement = new Vector3(x, y, 0) - transform.position;
            movement = Vector2.ClampMagnitude(movement, 1f);
            movement = movement * Speed * Time.deltaTime;
            Rb.MovePosition(Rb.position + movement);
        }
        
    }

}
