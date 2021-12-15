using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Vector2 orientation;
    public float movementSpeed;
    private float horizontalAxis;
    private float verticalAxis;
    public bool velocity;
    private bool playerAlive;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        movementSpeed = 1f;
        orientation = new Vector2(1, 0);
    }
    
    private void Update() {
        if (GetComponent<PlayerLife>().GetPlayerAlive()) {
            float horizontalAxis = Input.GetAxisRaw("Horizontal");
            float verticalAxis = Input.GetAxisRaw("Vertical");

            if (Input.GetKey(KeyCode.LeftShift)) {
                movementSpeed = 2f;
            } else {
                movementSpeed = 1f;
            }

            rigidBody.velocity = new Vector2(horizontalAxis, verticalAxis) * movementSpeed;

            if (horizontalAxis == 0 && verticalAxis == 0) {
                velocity = false;
            } else {
                orientation = new Vector2(horizontalAxis, verticalAxis);
                velocity = true;
            }
        }
    }

    public Vector2 GetOrientation()
    {
        return orientation;
    }

    public bool GetVelocity()
    {
        return velocity;
    }
}
