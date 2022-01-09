using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailScreen : UIBase
{
    private static FailScreen instance;
    public static FailScreen Instance => instance ?? (instance = FindObjectOfType<FailScreen>());
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    
    public void RestartLevelClick()
    {
        MySceneManager.Instance.RestarActiveScene();
    }
}
