using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private GameObject fade;
    [SerializeField]private int levelnumber;
    [SerializeField]private int waitsecond = 2;

    private void Start()
    {
        fade = GameObject.FindGameObjectWithTag("Fade");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(WaitForSecond());
        }
    }
    private IEnumerator WaitForSecond()
    {
        fade.GetComponent<Animator>().Play("StartTransFade");
        yield return new WaitForSeconds(waitsecond);
        SceneManager.LoadScene(levelnumber);
    }
}
