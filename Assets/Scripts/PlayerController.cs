using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float lerpMultiplier = 15;
    [SerializeField] private float velocityMultiplier = 2f;
    public float jumpForce = 5f;

    public static event GameManager.CollisionEvent OnCollision;
    public static event GameManager.TriggerEvent OnTrigger;

    private void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        if (gameManager == null)
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, Mathf.LerpAngle(transform.rotation.eulerAngles.z, Mathf.Min(Mathf.Max(rb.velocity.y * velocityMultiplier, -90), 90), Time.deltaTime * lerpMultiplier));
    }

    private void OnJump()
    {
        if (GameManager.isAlive)
        {
            rb.velocity = Vector2.up * jumpForce * (GameManager.GetDelay(0)/GameManager.GetDelay(GameManager.time));
        }
        else
        {
            gameManager.StartGame();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        OnCollision(other);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        OnTrigger(other);
    }
}
