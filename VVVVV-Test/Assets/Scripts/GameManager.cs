using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager Instance;

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

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

