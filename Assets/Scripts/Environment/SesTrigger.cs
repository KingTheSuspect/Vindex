using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource triggerses;
    private GameObject player;
    private bool triggered;
    private bool firsttime;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        firsttime = true;
    }
    private void Update()
    {
        if (triggered && firsttime)
        {
            firsttime = false;
            StartCoroutine(PlayGame());
            

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggered = true;
        
    }
    IEnumerator PlayGame()
    {
        triggerses.Play();
        player.GetComponent<PlayerController>().moveSpeed = 0;
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(7);
        player.GetComponent<PlayerController>().moveSpeed = 5;
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
}
