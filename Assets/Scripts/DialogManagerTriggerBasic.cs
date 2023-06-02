using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManagerTriggerBasic : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;
    private bool triggered;

    private void Start()
    {
        text.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (triggered && Input.GetKeyDown(KeyCode.E))
        {
            text.gameObject.SetActive(true);
        }
        else if (!triggered)
        {
            text.gameObject.SetActive(false);
        }
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
