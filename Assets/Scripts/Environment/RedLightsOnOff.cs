using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RedLightsOnOff : MonoBehaviour
{
    [SerializeField]private Light2D[] lights;
    public float minIntensity = 0f;      // Minimum ���k parlakl���
    public float maxIntensity = 1f;      // Maksimum ���k parlakl���
    public float flickerSpeed = 1f;      // Parlakl�k de�i�tirme h�z�
    private float targetIntensity;       // Hedef ���k parlakl���

    private void Update()
    {
        foreach (var item in lights)
        {
            // Mevcut ���k parlakl���n� hedef ���k parlakl���na do�ru de�i�tirme
            item.intensity = Mathf.Lerp(item.intensity, targetIntensity, flickerSpeed * Time.deltaTime);

            // Hedef ���k parlakl���n� de�i�tirme
            if (Mathf.Abs(item.intensity - targetIntensity) <= 0.05f)
            {
                // E�er mevcut hedef parlakl�k maksimum de�erdeyse, minimum de�ere ge�i� yap
                // Aksi halde, maksimum de�ere ge�i� yap
                targetIntensity = targetIntensity == maxIntensity ? minIntensity : maxIntensity;
            }
        }

    }
}
