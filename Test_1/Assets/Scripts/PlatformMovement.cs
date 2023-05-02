using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private Vector2 movement;
    [SerializeField]private float movementSpeed;

    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        rb.MovePosition(rb.position+movement*movementSpeed*Time.fixedDeltaTime);
    }
}
