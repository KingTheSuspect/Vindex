using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RedButton : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private DoorOpener dooropener;


    private GameObject player;
    private bool firsttime;

    private bool triggered;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {

        if (triggered)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
            dooropener.OpenDoor();
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
            dooropener.CloseDoor();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggered = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        triggered = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        triggered = false;
    }
}
