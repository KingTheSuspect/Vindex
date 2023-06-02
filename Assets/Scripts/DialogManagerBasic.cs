using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogManagerBasic : MonoBehaviour
{
    public GameObject dialogBox;        // Dialog kutusu oyun nesnesi
    public TextMeshProUGUI dialogText;     // Dialog metni

    private bool isDialogActive = false;     // Dialogun aktif olup olmad���n� belirten flag

    private void Start()
    {
        // Dialog kutusunu gizle
        dialogBox.SetActive(false);
    }

    private void Update()
    {
        // E�er dialog aktifse ve oyuncu "Space" tu�una bast�ysa dialogu kapat
        if (isDialogActive && Input.GetKeyDown(KeyCode.Space))
        {
            HideDialog();
        }
    }

    public void ShowDialog(string text)
    {
        // Dialog kutusunu g�ster
        dialogBox.SetActive(true);
        // Dialog metnini g�ncelle
        dialogText.text = text;
        // Dialogu aktif hale getir
        isDialogActive = true;
    }

    public void HideDialog()
    {
        // Dialog kutusunu gizle
        dialogBox.SetActive(false);
        // Dialogu pasif hale getir
        isDialogActive = false;
    }
}
