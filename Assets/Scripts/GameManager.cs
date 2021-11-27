using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public delegate void CollisionEvent(Collision2D collision);
    public delegate void TriggerEvent(Collider2D collider);

    public static float score;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void OnEnable()
    {
        PlayerController.OnCollision += ManageCollision;
        PlayerController.OnTrigger += ManageTrigger;
    }

    private void OnDisable()
    {
        PlayerController.OnCollision -= ManageCollision;
        PlayerController.OnTrigger -= ManageTrigger;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (scoreText == null) {
            scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ManageCollision(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Obstacle") {
            // TODO: Stop game
            Debug.Log("Game Over");
        }
    }
    private void ManageTrigger(Collider2D other)
    {
        if (other.gameObject.tag == "Food") {
            scoreText.text = (++score).ToString();
            other.gameObject.GetComponent<Food>().Collect();
        }
    }
}
