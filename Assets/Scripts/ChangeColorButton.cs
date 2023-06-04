using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeColorButton : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;
    private bool triggered;
    private RedLightsOnOff levelmanager;
    private bool firsttime = true;
    [SerializeField] private AudioSource[] sesler;
    private SpriteRenderer butonred;
    [SerializeField] private SpriteRenderer altkatman;
    [SerializeField] private Sprite[] gorseller;
    private GameObject player;
    [SerializeField] private GameObject duvargorunmez;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        text.gameObject.SetActive(false);
        levelmanager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<RedLightsOnOff>();
        firsttime = true;
        butonred = this.gameObject.GetComponent<SpriteRenderer>();
    }

    private bool isETapped = false;

    private void Update()
    {
        if (triggered && firsttime)
        {

            text.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E) && firsttime)
            {
                //Tamam artýk siren sesini ve kýrmýzý ýþýklarý kapatabilir miyiz lütfen
                firsttime = false;
                StartCoroutine(WaitForETap());

            }
        }
        else if (!triggered || !firsttime)
        {
            text.gameObject.SetActive(false);
        }
    }

    private IEnumerator WaitForETap()
    {
        player.GetComponent<PlayerController>().moveSpeed = 0;
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        //Tamam artýk siren sesini ve kýrmýzý ýþýklarý kapatabilir miyiz lütfen
        sesler[1].Play();
        yield return new WaitForSeconds(5);
        foreach (var item in levelmanager.lights)
        {
            item.color = Color.white;
            item.intensity = 1;

        }
        levelmanager.flickerSpeed = 0;
        sesler[0].Stop();
        butonred.sprite = gorseller[2];
        altkatman.sprite = gorseller[3];
        isETapped = true;
        yield return new WaitForSeconds(3);
        //Böylesi daha iyi
        sesler[2].Play();
        //mrhandtext.GetComponent<MrHandsText>().WriteText("MrHands: Hmm.. bu rengi sevmedim");
        yield return new WaitForSeconds(3);
        //mrhandtext.GetComponent<MrHandsText>().WriteText("");
        //Hatta rengi de deðiþtirirsek çok güzel olur
        //mrhandtext.GetComponent<MrHandsText>().WriteText("MrHands: Hatta rengi de degiþtirirsek çok güzel olur");
        sesler[3].Play();
        yield return new WaitForSeconds(3);
        //mrhandtext.GetComponent<MrHandsText>().WriteText("");
        foreach (var item in levelmanager.lights)
        {
            item.color = Color.cyan;
            item.intensity = 1;

        }
        player.GetComponent<PlayerController>().moveSpeed = 5;
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        duvargorunmez.SetActive(false);
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
