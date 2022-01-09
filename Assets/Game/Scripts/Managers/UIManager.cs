using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;

public class UIManager : UIBase
{
    #region Singleton
    private static UIManager instance;
    public static UIManager Instance => instance ?? (instance = FindObjectOfType<UIManager>());
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
    #endregion
    public void DisableStartScreen()
    {
        StartScreen.Instance.DisablePanel();
    }

    public void ActivateStartScreen()
    {
        StartScreen.Instance.EnablePanel();
    }

    public void DisableEndScreen()
    {
        EndScreen.Instance.DisablePanel();
    }

    public void ActivateEndScreen()
    {
        EndScreen.Instance.EnablePanel();
    }

    public void DisableFailScreen()
    {
        FailScreen.Instance.DisablePanel();
    }

    public void ActivateFailScreen()
    {
        FailScreen.Instance.EnablePanel();
    }
}
