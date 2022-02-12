using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void GoToGame()
    {
        StartCoroutine(LoadSceneAsync("MainGame"));
    }
    public void GoToSettings()
    {
        StartCoroutine(LoadSceneAsync("Settings"));
    }

    public void ExitGame()
    {
        SceneManager.OnApplicationQuit();
    }

    IEnumerator LoadSceneAsync(string _sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_sceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
