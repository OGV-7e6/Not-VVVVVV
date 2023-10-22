using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private static Camera Instance;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance != null)
            Destroy(gameObject);
        else
        {
            Instance = this;
        }
    }
}
