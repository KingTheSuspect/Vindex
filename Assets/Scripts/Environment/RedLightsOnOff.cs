using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RedLightsOnOff : MonoBehaviour
{
    [SerializeField]private Light2D[] lights;
    public float minIntensity = 0f;      // Minimum ýþýk parlaklýðý
    public float maxIntensity = 1f;      // Maksimum ýþýk parlaklýðý
    public float flickerSpeed = 1f;      // Parlaklýk deðiþtirme hýzý
    private float targetIntensity;       // Hedef ýþýk parlaklýðý

    private void Update()
    {
        foreach (var item in lights)
        {
            // Mevcut ýþýk parlaklýðýný hedef ýþýk parlaklýðýna doðru deðiþtirme
            item.intensity = Mathf.Lerp(item.intensity, targetIntensity, flickerSpeed * Time.deltaTime);

            // Hedef ýþýk parlaklýðýný deðiþtirme
            if (Mathf.Abs(item.intensity - targetIntensity) <= 0.05f)
            {
                // Eðer mevcut hedef parlaklýk maksimum deðerdeyse, minimum deðere geçiþ yap
                // Aksi halde, maksimum deðere geçiþ yap
                targetIntensity = targetIntensity == maxIntensity ? minIntensity : maxIntensity;
            }
        }

    }
}
