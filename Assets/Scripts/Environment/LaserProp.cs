using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LaserProp : MonoBehaviour
{
    [SerializeField] private float lazeraciksaniye;
    [SerializeField] private float lazerkapalisaniye;
    private void Start()
    {
        StartCoroutine(Baslat());
    }
    IEnumerator Baslat()
    {
        yield return new WaitForSeconds(lazeraciksaniye);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<LineRenderer>().enabled = false;
        gameObject.GetComponent<Light2D>().enabled = false;
        gameObject.GetComponent<AudioSource>().enabled = false;

        yield return new WaitForSeconds(lazerkapalisaniye);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<LineRenderer>().enabled = true;
        gameObject.GetComponent<Light2D>().enabled = true;
        gameObject.GetComponent<AudioSource>().enabled = true;
        StartCoroutine(Baslat());

    }
}
