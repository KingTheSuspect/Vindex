using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Lasersforboss : MonoBehaviour
{
    private GameObject triggerone;
    private bool startfirst;

    private void Start()
    {
        triggerone = GameObject.FindGameObjectWithTag("LevelManager");
        startfirst = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<LineRenderer>().enabled = false;
        gameObject.GetComponent<Light2D>().enabled = false;
        gameObject.GetComponent<AudioSource>().enabled = false;
        
    }
    private void Update()
    {
        if (triggerone.GetComponent<RedButtonBoss>().baslat == true && startfirst)
        {
            startfirst = false;
            StartCoroutine(Baslat());
        }
    }

    private IEnumerator Baslat()
    {
        int i;
        i = Random.Range(1, 10);
        int sure;
        sure = Random.Range(1, 4);
        if (i < 3)
        {
            yield return new WaitForSeconds(2);
            gameObject.GetComponent<Light2D>().enabled = true;
            gameObject.GetComponent<LineRenderer>().enabled = true;
            gameObject.GetComponent<LineRenderer>().startColor = Color.yellow;
            gameObject.GetComponent<LineRenderer>().endColor = Color.yellow;
            gameObject.GetComponent<Light2D>().color = Color.yellow;
            yield return new WaitForSeconds(sure);
            gameObject.GetComponent<LineRenderer>().startColor = Color.magenta;
            gameObject.GetComponent<LineRenderer>().endColor = Color.magenta;
            gameObject.GetComponent<Light2D>().color = Color.magenta;
            yield return new WaitForSeconds(sure);
            gameObject.GetComponent<LineRenderer>().startColor = Color.red;
            gameObject.GetComponent<LineRenderer>().endColor = Color.red;
            gameObject.GetComponent<Light2D>().color = Color.red;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponent<AudioSource>().enabled = true;
            yield return new WaitForSeconds(sure);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<LineRenderer>().enabled = false;
            gameObject.GetComponent<Light2D>().enabled = false;
            gameObject.GetComponent<AudioSource>().enabled = false;

        }
        else
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<LineRenderer>().enabled = false;
            gameObject.GetComponent<Light2D>().enabled = false;
            gameObject.GetComponent<AudioSource>().enabled = false;
            yield return new WaitForSeconds(5);
        }
        StartCoroutine(Baslat());

    }
}
