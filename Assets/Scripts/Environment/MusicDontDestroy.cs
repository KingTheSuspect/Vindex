using UnityEngine;

public class MusicDontDestroy : MonoBehaviour
{
    private static MusicDontDestroy instance;
    private AudioSource musicSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        musicSource = GetComponent<AudioSource>();
    }
}
