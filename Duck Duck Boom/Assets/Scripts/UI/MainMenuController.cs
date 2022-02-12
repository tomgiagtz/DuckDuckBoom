using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void LoadScene(string _sceneName)
    {
        StartCoroutine(LoadSceneAsync(_sceneName));
    }

    public void ExitGame()
    {
        Application.Quit();
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
