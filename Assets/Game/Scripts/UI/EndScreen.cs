using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : UIBase
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
}
