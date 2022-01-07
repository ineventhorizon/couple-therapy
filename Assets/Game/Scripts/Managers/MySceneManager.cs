using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NaughtyAttributes;


public class MySceneManager : MonoBehaviour
{
    //TO DO
    //THIS DOES NOT WORK YET IT IS FOR TESTING
    //THIS DOES NOT WORK YET IT IS FOR TESTING
    //THIS DOES NOT WORK YET IT IS FOR TESTING
    //THIS DOES NOT WORK YET IT IS FOR TESTING
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
    }

    [Button]
    public void NextScene()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.UnloadSceneAsync(1);
        SceneManager.UnloadSceneAsync(2);
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
        SceneManager.LoadScene(3, LoadSceneMode.Additive);
    }
}
