using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using static UnityEditor.Progress;
using UnityEngine.SceneManagement;

public class lazerplayer : MonoBehaviour
{
    //[SerializeField] private AudioSource[] sesl;
    private bool triggered;
    //[SerializeField] private Sprite[] sprites;
    private bool salak;
    [SerializeField] private GameObject isikatom;
    private bool timehascome;

    public float minIntensity = 0f;      // Minimum ���k parlakl���
    public float maxIntensity = 1f;      // Maksimum ���k parlakl���
    public float flickerSpeed = 1f;      // Parlakl�k de�i�tirme h�z�
    private float targetIntensity;       // Hedef ���k parlakl���

    private void Start()
    {
        salak = true;
        timehascome = false;
    }

    private void Update()
    {
        if (timehascome)
        {
            // Mevcut ���k parlakl���n� hedef ���k parlakl���na do�ru de�i�tirme
            isikatom.GetComponent<Light2D>().intensity = Mathf.Lerp(isikatom.GetComponent<Light2D>().intensity, targetIntensity, flickerSpeed * Time.deltaTime);

            // Hedef ���k parlakl���n� de�i�tirme
            if (Mathf.Abs(isikatom.GetComponent<Light2D>().intensity - targetIntensity) <= 0.05f)
            {
                // E�er mevcut hedef parlakl�k maksimum de�erdeyse, minimum de�ere ge�i� yap
                // Aksi halde, maksimum de�ere ge�i� yap
                targetIntensity = targetIntensity == maxIntensity ? minIntensity : maxIntensity;
            }
        }

        if (triggered && salak)
        {


            salak = false;
            //gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];

            StartCoroutine(Baslat());
        }
    }



    private IEnumerator Baslat()
    {
        //sesl[0].Play();
        yield return new WaitForSeconds(4);
        timehascome = true;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(10);



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
