using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScenePreloader : MonoBehaviour
{
    private AsyncOperation asyncLoad;

    public bool IsReady { get; private set; }

    void Start()
    {
        StartPreloading("0 (36)");
    }

    public void StartPreloading(string sceneName)
    {
        StartCoroutine(PreloadSceneCoroutine(sceneName));
    }

    private IEnumerator PreloadSceneCoroutine(string sceneName)
    {
        asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;

        // Wait until Unity has loaded the scene to 90%
        while (asyncLoad.progress < 0.9f)
        {
            yield return null;
        }

        IsReady = true;

        Debug.Log("Scene 0 (36) is fully preloaded and ready!");
    }

    public void ActivatePreloadedScene()
    {
        if (asyncLoad != null && IsReady)
        {
            asyncLoad.allowSceneActivation = true;
        }
        else
        {
            Debug.Log("Scene is not finished preloading yet!");
        }
    }
}