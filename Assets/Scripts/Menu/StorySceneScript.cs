using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StorySceneScript : MonoBehaviour
{
    public Sprite[] photos;
    public string[] textforimages;
    public GameObject image;
    public TextMeshProUGUI Rtext;
    public float typingSpeed = 0.1f;

    private void Start()
    {
        StartCoroutine(OnWake());
    }

    private IEnumerator OnWake()
    {
        for (int i = 0; i < photos.Length; i++)
        {
            yield return StartCoroutine(ShowImageWithText(photos[i], textforimages[i]));
            yield return new WaitForSeconds(5);
        }
    }

    private IEnumerator ShowImageWithText(Sprite sprite, string text)
    {
        image.GetComponent<Image>().sprite = sprite;
        Rtext.text = "";

        for (int i = 0; i < text.Length; i++)
        {
            Rtext.text += text[i];
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}