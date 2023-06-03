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
    private int Esayar;
    [SerializeField]private AudioSource[] sesler;
    private SpriteRenderer butonred;
    [SerializeField] private SpriteRenderer altkatman;
    [SerializeField] private Sprite[] gorseller;
    //private GameObject mrhandtext;

    private void Start()
    {
        text.gameObject.SetActive(false);
        levelmanager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<RedLightsOnOff>();
        firsttime = true;
        butonred = this.gameObject.GetComponent<SpriteRenderer>();
        //mrhandtext = GameObject.FindGameObjectWithTag("MrHands");
        //mrhandtext.GetComponent<MrHandsText>().WriteText("");
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
        Esayar = 0;
        //Tamam artýk siren sesini ve kýrmýzý ýþýklarý kapatabilir miyiz lütfen
        sesler[1].Play();
        //mrhandtext.GetComponent<MrHandsText>().WriteText("MrHands: Tamam artik siren sesini ve kirmizi isiklari kapatabilir miyiz lütfen");
        yield return new WaitForSeconds(4);
        //mrhandtext.GetComponent<MrHandsText>().WriteText("");

        while (!isETapped)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Esayar++;
            }
            else if (Esayar == 2)
            {
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
            }
            yield return null;
        }
        

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
