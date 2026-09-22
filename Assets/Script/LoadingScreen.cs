using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(LoadGame());
    }

    private IEnumerator LoadGame()
    {
        yield return null;

        AsyncOperation operation =
            SceneManager.LoadSceneAsync("Scene01");

        while (!operation.isDone)
        {
            yield return null;
        }
    }
}