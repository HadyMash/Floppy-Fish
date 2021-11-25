using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 10f;

    private void OnJump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }
}
