using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float lerpMultiplier = 15;
    [SerializeField] private float velocityMultiplier = 2f;
    public float jumpForce = 5f;

    private void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, Mathf.LerpAngle(transform.rotation.eulerAngles.z, Mathf.Min(Mathf.Max(rb.velocity.y * velocityMultiplier, -90), 90), Time.deltaTime * lerpMultiplier));
    }

    private void OnJump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }
}
