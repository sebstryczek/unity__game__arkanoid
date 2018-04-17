using UnityEngine;
using UnityEngine.SceneManagement;

public class AppFlowManager : Singleton<AppFlowManager>
{
    public bool IsPaused { get; private set; }

    private void Awake()
    {
        this.IsPaused = false;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        this.IsPaused = true;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        this.IsPaused = false;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoToMenuAndSave()
    {
        GameStateManager.Instance.Save();
        SceneManager.LoadScene("Menu");
    }

    public void GoToLeaderboard()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    public void GoToNewGame()
    {
        GameStateManager.Instance.Create();
        SceneManager.LoadScene("Game");
    }

    public void GoToSavedGame()
    {
        GameStateManager.Instance.Load();
        SceneManager.LoadScene("Game");
    }
}
