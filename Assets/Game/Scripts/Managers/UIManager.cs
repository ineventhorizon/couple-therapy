using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;

public class UIManager : MonoBehaviour
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
        StartScreen.Instance.DisableStartScreen();
    }

    public void ActivateStartScreen()
    {
        StartScreen.Instance.ActivateStartScreen();
    }
}
