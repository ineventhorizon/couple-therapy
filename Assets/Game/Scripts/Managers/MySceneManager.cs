using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NaughtyAttributes;


public class MySceneManager : MonoBehaviour
{
    private int currentLevelIndex = 2;
    private List<AsyncOperation> scenesUnLoading = new List<AsyncOperation>();
    private static MySceneManager instance;
    public static MySceneManager Instance => instance ?? (instance = FindObjectOfType<MySceneManager>());
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    [Button]
    public void NextScene()
    {
        //Check if there are no more levels to load
        if (currentLevelIndex + 1 == SceneManager.sceneCountInBuildSettings) return;
        UnloadActiveScene();
        currentLevelIndex++;
        LoadScenes(currentLevelIndex);
    }

    [Button]
    public void RestarActiveScene()
    {
        UnloadActiveScene();
        LoadScenes(currentLevelIndex);
    }

    //Unloads Active Scene and UI
    private void UnloadActiveScene()
    {
        scenesUnLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.UI));
        scenesUnLoading.Add(SceneManager.UnloadSceneAsync(currentLevelIndex));
        StartCoroutine(WaitForSceneUnload());
    }
    private void LoadScenes(int index)
    {
        SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
        AsyncOperation asyncLoadScene = SceneManager.LoadSceneAsync((int)SceneIndexes.UI, LoadSceneMode.Additive);
        Debug.Log(SceneManager.GetSceneByBuildIndex(index).name);
        StartCoroutine(WaitForSceneLoad(asyncLoadScene));
    }
    public IEnumerator WaitForSceneLoad(AsyncOperation scene)
    {
        while (!scene.isDone)
        {
            yield return null;
        }
        Debug.Log("Setting active scene..");
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(currentLevelIndex));
    }

    public IEnumerator WaitForSceneUnload()
    {
        for(int i = 0; i < scenesUnLoading.Count; i++)
        {
            while (!scenesUnLoading[i].isDone)
            {
                yield return null;
            }
        }
    }
}
