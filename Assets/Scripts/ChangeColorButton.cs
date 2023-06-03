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

    private void Start()
    {
        text.gameObject.SetActive(false);
        levelmanager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<RedLightsOnOff>();
        firsttime = true;
    }

    private bool isETapped = false;

    private void Update()
    {
        if (triggered && firsttime)
        {

            text.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E) && firsttime)
            {
                // E tu�una bas�lana kadar oyunun durmas�n� sa�lar
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
                foreach (var item in levelmanager.lights)
                {
                    item.color = Color.white;
                }
                isETapped = true;
            }
            yield return null;
        }



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
