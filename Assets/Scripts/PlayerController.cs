using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 5f;

    private void OnJump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }
}
