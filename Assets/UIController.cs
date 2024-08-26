using UnityEngine;
using UnityEngine.SceneManagement; 

public class UIController : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject gameOverScreen;
    public GameObject gameUI;

    private void Start()
    {
        ShowStartScreen();
        Time.timeScale = 0; 
    }

    public void ShowStartScreen()
    {
        startScreen.SetActive(true);
        gameOverScreen.SetActive(false);
        gameUI.SetActive(false);
    }

    public void ShowGameOverScreen()
    {
        startScreen.SetActive(false);
        gameOverScreen.SetActive(true);
        gameUI.SetActive(false);
    }

    public void StartGame()
    {
        startScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        gameUI.SetActive(true);
      
        Time.timeScale = 1; 
    }

    public void RestartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       
    }

    public void ExitGame()
    {
       
        Application.Quit();
    }
}
