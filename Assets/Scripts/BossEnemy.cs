using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using static UnityEditor.Progress;

public class BossEnemy : MonoBehaviour
{
    public GameObject[] Lasers;     // Lazer nesneleri
    private GameObject triggerone;
    private bool startfirst;
    [SerializeField] private GameObject lazerplayer;

    private void Start()
    {
        triggerone = this.gameObject;
        startfirst = true;
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
        yield return new WaitForSeconds(50);

        for (int i = 0; i < Lasers.Length; i++)
        {
            Lasers[i].SetActive(false);
        }
        lazerplayer.SetActive(true);

    }



}
