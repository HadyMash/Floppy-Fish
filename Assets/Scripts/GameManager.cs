using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private List<GameObject> obstacles;
    [SerializeField] private Rigidbody2D playerRigidBody;
    public delegate void CollisionEvent(Collision2D collision);
    public delegate void TriggerEvent(Collider2D collider);

    public static float score;
    public static float time;
    public static bool isAlive = false;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private float xSpawnOffset = 6f;
    [SerializeField] private float minYSpawnOffset = -4f;
    [SerializeField] private float maxYSpawnOffset = 4f;
    #endregion

    #region Methods
    // Gets a delay between spawning obstacles in seconds
    static public float GetDelay(float t)
    {
        // f(x)
        float f(float x) {
            return -0.02f * (x - 25f) + 4f;
        }

        if (t <= 25f) 
        {
            return 4f;
        } else if (25f < t && t <= 90f)
        {
            return f(t);
        } else {
            return f(90f);
        }
    }
    public void StartGame() {
        isAlive = true;
        score = 0f;
        time = 0f;
        StartCoroutine(SpawnObstacles());
    }
    #endregion
    
    #region Unity Methods
    IEnumerator SpawnObstacles() {
        while (isAlive) {
            float delay = GetDelay(time);
            playerRigidBody.gravityScale = 2f * (GetDelay(0)/delay);

            GameObject obstacle = obstacles[Random.Range(0, obstacles.Count - 1)];
            Vector2 position = new Vector2(xSpawnOffset, Random.Range(minYSpawnOffset, maxYSpawnOffset));

            Instantiate(obstacle, position, Quaternion.identity);
            yield return new WaitForSeconds(delay);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (scoreText == null) {
            scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        }
        if (playerRigidBody == null) {
            playerRigidBody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }
    #endregion

    #region Collision
    // Subscribe and unsubscribe to collision events
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
    // Manage collisions
    private void ManageCollision(Collision2D other)
    {
        print(other.gameObject.tag);
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
    #endregion
}
