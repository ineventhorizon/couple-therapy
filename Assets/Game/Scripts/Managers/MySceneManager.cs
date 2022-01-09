using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NaughtyAttributes;


public class MySceneManager : MonoBehaviour
{
    private int currentLevelIndex = 2;
    private List<AsyncOperation> scenesLoading = new List<AsyncOperation>();
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
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Total {SceneManager.sceneCount}");
        //LoadScenes(2);
    }

    [Button]
    public void NextScene()
    {
        //var index = SceneManager.GetActiveScene().buildIndex;
        UnloadActiveScene();
        LoadScenes(currentLevelIndex+1);
        currentLevelIndex++;
    }

    //Unloads Active Scene, Managers and UI
    private void UnloadActiveScene()
    {
        //SceneManager.UnloadSceneAsync((int)SceneIndexes.Managers);
        SceneManager.UnloadSceneAsync((int)SceneIndexes.UI);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
    private void LoadScenes(int index)
    {
        SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
        AsyncOperation abc = SceneManager.LoadSceneAsync((int)SceneIndexes.UI, LoadSceneMode.Additive);
        StartCoroutine(WaitForSceneLoad(SceneManager.GetSceneByBuildIndex(index)));
    }
    public IEnumerator WaitForSceneLoad(Scene scene)
    {
        while (!scene.isLoaded)
        {
            yield return null;
        }
        Debug.Log("Setting active scene..");
        SceneManager.SetActiveScene(scene);
    }

    public void RestarActivetScene()
    {
        UnloadActiveScene();
        LoadScenes(SceneManager.GetActiveScene().buildIndex);
    }

    
}
