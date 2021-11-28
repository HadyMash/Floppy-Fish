using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private GameObject plusOneText;

    private readonly List<Color> colors = new List<Color>{
        new Color((float)255/255, (float)247/255, (float)107/255), // White
        new Color((float)255/255, (float)247/255, (float)107/255), // Yellow
        new Color((float)128/255, (float)226/255, (float)95/255), // Green
        new Color((float)255/255, (float)107/255, (float)107/255), // Red
        new Color((float)128/255, (float)107/255, (float)226/255), // Purple
        new Color((float)107/255, (float)255/255, (float)211/255), // Grue??
        new Color((float)250/255, (float)160/255, (float)255/255), // Pink
    };
    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Count - 1)];
    }
    public void Collect() {
        Instantiate(plusOneText, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
