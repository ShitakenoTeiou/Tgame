using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyObj : MonoBehaviour
{
    public string UserName;
    public string UserRegion;
    public static DontDestroyObj Instance
    {
        get; private set;
    }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
