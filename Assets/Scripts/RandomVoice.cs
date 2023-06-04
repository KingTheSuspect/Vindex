using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RandomVoice : MonoBehaviour
{
    [SerializeField] private AudioSource[] sesler;
    private int gelensayi;
    private int gelenses;

    private void Start()
    {
        StartCoroutine(GiveVoice());
    }
    IEnumerator GiveVoice()
    {
        yield return new WaitForSeconds(5);
        gelensayi = Random.Range(1, 10);
        gelenses = Random.Range(1, sesler.Length);
        if (gelensayi > 6)
        {
            sesler[gelenses].Play();
        }
        yield return new WaitForSeconds(25);
        StartCoroutine(GiveVoice());

       
    }
}
