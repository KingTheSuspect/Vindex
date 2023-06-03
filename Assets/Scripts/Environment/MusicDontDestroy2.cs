using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class MusicDontDestroy2 : MonoBehaviour
{
    private static MusicDontDestroy2 instance;
    [SerializeField] private int whichscenedestory;

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
        Scene activeScene = SceneManager.GetActiveScene();
        if (activeScene.buildIndex == whichscenedestory)
        {
            Destroy(gameObject);
        }
    }
}
