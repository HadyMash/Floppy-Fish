using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] readonly private Rigidbody2D rb;
    public float jumpForce = 5f;

    private void OnJump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }
}
