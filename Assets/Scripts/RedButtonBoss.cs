using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RedButtonBoss : MonoBehaviour
{
    [SerializeField] private DoorOpener dooropener;
    [SerializeField] private Camera Disp1;
    [SerializeField] private Camera Disp2;
    [SerializeField] private Transform playerpoint;
    [SerializeField] private float hiz;
    [SerializeField] private AudioSource[] sesler;
    public float hedefToleransi = 0.1f;
    public bool hedefeUlasti = false;
    private bool hfdulasti;



    private GameObject player;

    private bool triggered;
    private bool started;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Disp2.gameObject.SetActive(false);
        started = false;
        hfdulasti = false;
        
    }

    private void Update()
    {

        if (triggered)
        {
            started = true;
            StartCoroutine(timls());

        }
        if (started && !hfdulasti)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, playerpoint.position, hiz * Time.deltaTime);

            // Hedef noktaya ulaþýldýðýný kontrol etme
            if (Vector3.Distance(player.transform.position, playerpoint.position) <= hedefToleransi)
            {
                hedefeUlasti = true;
            }
            if (hedefeUlasti && !hfdulasti)
            {
                hfdulasti = true;
                player.GetComponent<Animator>().SetBool("BossAnim", false);
                player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                player.GetComponent<PlayerController>().enabled = true;
            }
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
    IEnumerator timls()
    {
        player.GetComponent<Animator>().SetBool("BossAnim", true);
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        player.GetComponent<PlayerController>().enabled = false;
        yield return new WaitForSeconds(3);
        dooropener.OpenDoor();
        Disp1.gameObject.SetActive(false);
        Disp2.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        sesler[0].Play();
    }
}
