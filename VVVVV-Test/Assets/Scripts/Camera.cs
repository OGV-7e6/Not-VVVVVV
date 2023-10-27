using UnityEngine;
using UnityEngine.SceneManagement;

public class Camera : MonoBehaviour
{
    private static Camera Instance;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu") Destroy(Instance.gameObject);
    }
}
