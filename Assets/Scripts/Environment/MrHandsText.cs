using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MrHandsText : MonoBehaviour
{
 

    public void WriteText(string yazi)
    {
        GetComponent<TextMeshProUGUI>().text =  yazi;
    }
}
