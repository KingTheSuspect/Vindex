using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManagerTriggerBasic : MonoBehaviour
{
    public TMPro.TextMeshProUGUI textkonus;
    public TMPro.TextMeshProUGUI pressE;
    private bool triggered;
    private bool chatactive;
    [SerializeField] private string[] konusmalar;
    private int sayici;

    private void Start()
    {
        textkonus.gameObject.SetActive(false);
        chatactive = false;
    }

    private void Update()
    {
        if (triggered && !chatactive)
        {
            pressE.text = "E";
        }
        if (triggered && Input.GetKeyDown(KeyCode.E))
        {
            sayici++;
            textkonus.gameObject.SetActive(true);
            chatactive = true;
            pressE.text = "";
            for (int i = 0; i < sayici; i++)
            {
               textkonus.text = konusmalar[i];
            }


        }
        else if (!triggered)
        {
            textkonus.gameObject.SetActive(false);
            pressE.text = "";
            chatactive = false;
            sayici = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            triggered = true;
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            triggered = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            triggered = false;
        }
    }
}
