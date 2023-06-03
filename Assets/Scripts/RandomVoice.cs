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
        yield return new WaitForSeconds(50);
        gelensayi = Random.Range(1, 10);
        gelenses = Random.Range(1, sesler.Length);
        if (gelensayi > 5)
        {
            sesler[gelenses].Play();
        }
        StartCoroutine(GiveVoice());
       
    }
}
