using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance ?? (instance = FindObjectOfType<GameManager>());
    public bool isGameRunning = false;
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

    private void OnEnable()
    {
        Observer.startGame += StartGame;
    }

    private void OnDisable()
    {
        Observer.startGame -= StartGame;
    }

    [Button]
    public void StartGame()
    {
        //Time.timeScale = 1;
        UIManager.Instance.DisableStartScreen();
        Observer.startPlayerMovement?.Invoke();
        isGameRunning = true;
    }   
}
