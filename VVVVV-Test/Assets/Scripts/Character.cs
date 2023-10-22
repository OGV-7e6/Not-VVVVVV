using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private static Character Instance;


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
