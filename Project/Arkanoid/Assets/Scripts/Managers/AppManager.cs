using UnityEngine;
using UnityEngine.SceneManagement;

public class AppManager : Singleton<AppManager>
{
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoToLeaderboard()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    public void GoToNewGame()
    {
        StateManager.Instance.CreateEmptyState();
        SceneManager.LoadScene("Game");
    }

    public void GoToSavedGame()
    {
        StateManager.Instance.LoadState();
        SceneManager.LoadScene("Game");
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    
    public void ContinueGame()
    {
        Time.timeScale = 1;
    }
}
