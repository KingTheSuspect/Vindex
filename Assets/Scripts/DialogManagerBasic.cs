using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogManagerBasic : MonoBehaviour
{
    public GameObject dialogBox;        // Dialog kutusu oyun nesnesi
    public TextMeshProUGUI dialogText;     // Dialog metni

    private bool isDialogActive = false;     // Dialogun aktif olup olmadýðýný belirten flag

    private void Start()
    {
        // Dialog kutusunu gizle
        dialogBox.SetActive(false);
    }

    private void Update()
    {
        // Eðer dialog aktifse ve oyuncu "Space" tuþuna bastýysa dialogu kapat
        if (isDialogActive && Input.GetKeyDown(KeyCode.Space))
        {
            HideDialog();
        }
    }

    public void ShowDialog(string text)
    {
        // Dialog kutusunu göster
        dialogBox.SetActive(true);
        // Dialog metnini güncelle
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
