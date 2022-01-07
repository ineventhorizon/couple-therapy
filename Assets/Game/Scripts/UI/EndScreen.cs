using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{

    //TO DO
    private static EndScreen instance;
    public static EndScreen Instance => instance ?? (instance = FindObjectOfType<EndScreen>());
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
    public void DisableEndScreen()
    {
        this.gameObject.SetActive(false);
        this.enabled = false;
    }

    public void ActivateEndScreen()
    {
        this.gameObject.SetActive(true);
        this.enabled = true;
    }
}
