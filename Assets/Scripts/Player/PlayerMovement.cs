using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 10f;

    private bool IsInputActive = true;
    private float HorizontalMovementInputValue;
    private float VerticalMovementInputValue;

    private Rigidbody2D Rb;

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HorizontalMovementInputValue = Input.GetAxis("Horizontal");
        VerticalMovementInputValue = Input.GetAxis("Vertical");
    }

    public void ActivateInput()
    {
        IsInputActive = true;
    }

    public void DeactivateInput()
    {
        IsInputActive = false;
    }

    private void FixedUpdate()
    {
        if (IsInputActive)
        {
            Move();
        }
    }

    private void Move()
    {
        Vector2 movement = transform.right * HorizontalMovementInputValue + transform.up * VerticalMovementInputValue;
        movement = Vector2.ClampMagnitude(movement, 1f);
        /* This caps the player speed at 1.
         * Without this, combining x and y vecotrs with length of 1 would create a vecotr with length of sqrt(2).
         * This doesn't affect acceleration: Diagonal movement still accelerates the player faster.
         * You can try fixing this problem but it doesn't seem very relevant.
         * */
        movement = movement * Speed * Time.deltaTime;

        Rb.MovePosition(Rb.position + movement);
    }
}
