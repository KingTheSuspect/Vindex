using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private int playsceneid;
    [SerializeField] private int settingsceneid;
    public void Play()
    {
        SceneManager.LoadScene(playsceneid);
    }
    public void Settings()
    {
        SceneManager.LoadScene(settingsceneid);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
