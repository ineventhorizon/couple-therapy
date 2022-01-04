using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private LoveBar loveBar;

    void Start()
    {
        // TODO later on, set the maxlove via gamemanager or scriptableobject
        loveBar.SetMaxLove(30);
    }

    public void UpdateLove(float value)
    {
        loveBar.UpdateLoveBar(value);
    }
}
