using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButtonAraScene : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private DoorOpener dooropener;
    [SerializeField] private AudioSource audioses;
    [SerializeField] private GameObject ETusu;

    
    private GameObject player;
    private bool firsttime;

    private bool triggered;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        firsttime = true;
    }

    private void Update()
    {
        if (triggered && firsttime)
        {
            ETusu.SetActive(true);
        }
        else
        {
            ETusu.SetActive(false);
        }

        if (triggered && firsttime)
        {
            firsttime = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
            dooropener.OpenDoor();
            StartCoroutine(PlaySome());



        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggered = true;
    }
    IEnumerator PlaySome()
    {
        audioses.Play();
        player.GetComponent<PlayerController>().moveSpeed = 0;
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(4);
        player.GetComponent<PlayerController>().moveSpeed = 5;
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

    }
}
