using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private GameObject plusOneText;
    public void Collect() {
        Instantiate(plusOneText, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
