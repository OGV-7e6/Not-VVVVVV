using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private static GameManager Instance;
    public string _levelBeforePause;
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
        if (Input.GetKeyDown(KeyCode.Escape) && 
            (SceneManager.GetActiveScene().name != "MainMenu" ||
            SceneManager.GetActiveScene().name != "PauseMenu" ||
            SceneManager.GetActiveScene().name != "Level_Final"))
        {
            _levelBeforePause = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("PauseMenu");
        }
    }



    //UI
    public void sceneChanger(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void resumeGame()
    {
        SceneManager.LoadScene(_levelBeforePause);
    }
    public void exitGame() 
    {
        Application.Quit();
    }
}
