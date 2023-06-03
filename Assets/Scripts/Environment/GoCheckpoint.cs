using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoCheckpoint : MonoBehaviour
{
    [SerializeField] private GameObject checkpoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Transform>().position = checkpoint.GetComponent<Transform>().position;
        }
    }
}
