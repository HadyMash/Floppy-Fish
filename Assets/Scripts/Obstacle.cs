using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] public static float speed = 1f;
    
    private void OnEnable()
    {
        GameManager.onGameOver += Stop;
    }
    private void OnDisable()
    {
        GameManager.onGameOver -= Stop;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Barrier") {
            Destroy(gameObject);
        }
    }

    void Stop() {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
