using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Otomatiksahnegecici : MonoBehaviour
{
    public Camera cameras;
    public float zoomDuration;
    public float targetZoom;

    private float initialZoom;
    private float timer;

    void Start()
    {
        initialZoom = cameras.orthographicSize;
        timer = 0f;
        StartCoroutine(ZoomCoroutine());
    }

    private IEnumerator ZoomCoroutine()
    {

        while (timer < zoomDuration)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / zoomDuration);

            float currentZoom = Mathf.Lerp(initialZoom, targetZoom, t);
            cameras.orthographicSize = currentZoom;

            yield return null;
        }

        cameras.orthographicSize = targetZoom;


        // Wait for an additional 10 seconds before loading the next scene
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(10);
    }
}
