using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlusOneFade : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;
    [SerializeField] private float fadeTime = 1.25f;
    
    // Start is called before the first frame update
    void Start()
    {
        if (text == null) {
            text = GetComponent<TextMeshPro>();
        }

        StartCoroutine(FadeTextToZeroAlpha(fadeTime));
    }

    IEnumerator FadeTextToZeroAlpha(float t) {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.0f) {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / t));
            yield return null;
        }
        Destroy(gameObject);
    }
}
