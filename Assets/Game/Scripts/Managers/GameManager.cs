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
        Observer.finalWalk += FinalWalk;
    }

    private void OnDisable()
    {
        Observer.startGame -= StartGame;
        Observer.finalWalk -= FinalWalk;
    }

    [Button]
    public void StartGame()
    {
        //Time.timeScale = 1;
        UIManager.Instance.DisableStartScreen();
        Observer.startPlayerMovement?.Invoke();
        isGameRunning = true;
    }

    public void FinalWalk()
    {
        isGameRunning = false;
        Debug.Log("Game ended!");
        var posOffSet = LoveBar.currLove * 3.5f;
        var newPos =  posOffSet* Vector3.forward;
        Debug.Log($"{newPos} {LoveBar.currLove}");
        Observer.finalMoveTowards?.Invoke(newPos);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        //SCENE MANAGER RELOAD CURRENT SCENE
    }
    public void NextLevel()
    {
        UIManager.Instance.ActivateEndScreen();
        //SCENEMANAGER NEXT SCENE
    }
}
