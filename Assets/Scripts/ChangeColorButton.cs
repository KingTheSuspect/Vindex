using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorButton : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;
    private bool triggered;
    private RedLightsOnOff levelmanager;
    private bool firsttime = true;
    private int Esayar;
    [SerializeField]private AudioSource siren;
    private SpriteRenderer butonred;
    [SerializeField] private SpriteRenderer altkatman;
    [SerializeField] private Sprite[] gorseller;

    private void Start()
    {
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
                // E tuþuna basýlana kadar oyunun durmasýný saðlar
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
        while (!isETapped)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Esayar++;
            }
            else if (Esayar == 2)
            {
                yield return new WaitForSeconds(3);
                //Dialog
                //StopGame
                foreach (var item in levelmanager.lights)
                {
                    item.color = Color.white;
                    item.intensity = 1;

                }
                levelmanager.flickerSpeed = 0;
                
                isETapped = true;
            }
            yield return null;
        }

        butonred.sprite = gorseller[2];
        altkatman.sprite = gorseller[3];
        siren.Stop();
        firsttime = false;
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
