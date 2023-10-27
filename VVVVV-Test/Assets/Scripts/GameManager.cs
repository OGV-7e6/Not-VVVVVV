using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager Instance;
    [SerializeField] private GameObject _canvasPause;




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
            SceneManager.GetActiveScene().name != "MainMenu" &&
            SceneManager.GetActiveScene().name != "Level_Final")
        {
            _canvasPause.SetActive(true);
        }
    }
        


    //UI
    public void sceneChanger(string scene)
    {
        SceneManager.LoadScene(scene);
        _canvasPause.SetActive(false);
    }
    public void resumeGame()
    {
        _canvasPause.SetActive(false);
    }
    public void exitGame() 
    {
        Application.Quit();
        _canvasPause.SetActive(false);
    }
}
