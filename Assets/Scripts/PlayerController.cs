using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float rotationLerpMultiplier = 15f;
    [SerializeField] private float velocityMultiplier = 2f;
    public float jumpForce = 5f;
    public float swimSpeed = 5f;

    public static event GameManager.CollisionEvent OnCollision;
    public static event GameManager.TriggerEvent OnTrigger;

    public static GameMode gameMode = GameMode.flappy;
    public enum GameMode {
        flappy,
        swim,
    }

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

        if (gameMode == GameMode.swim)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            gameObject.GetComponent<PlayerInput>().SwitchCurrentActionMap("Swim");
        } else {
            gameObject.GetComponent<PlayerInput>().SwitchCurrentActionMap("Flappy");
        }
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, Mathf.LerpAngle(transform.rotation.eulerAngles.z, Mathf.Min(Mathf.Max(rb.velocity.y * velocityMultiplier, -90), 90), Time.deltaTime * rotationLerpMultiplier));
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!GameManager.isAlive)
            {
                gameManager.StartGame();
            }
            rb.velocity = Vector2.up * jumpForce * (GameManager.GetDelay(0)/GameManager.GetDelay(GameManager.time));
        }
    }
    public void OnMove(InputAction.CallbackContext context) {
        if (context.performed)
        {
            if (!GameManager.isAlive)
            {
                gameManager.StartGame();
            }

            // rb.velocity = Vector2.Lerp(rb.velocity, new Vector2(0, context.ReadValue<float>() * swimSpeed * (GameManager.GetDelay(0) / GameManager.GetDelay(GameManager.time))), Time.deltaTime * swimLerpMultiplier);
            rb.velocity = new Vector2(0, context.ReadValue<float>() * swimSpeed * (GameManager.GetDelay(0) / GameManager.GetDelay(GameManager.time)));
        } else if (context.canceled)
        {
            // rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, Time.deltaTime * 1000 *  swimLerpMultiplier);
            rb.velocity = Vector2.zero;
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

