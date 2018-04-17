using UnityEngine;
using UnityEngine.SceneManagement;

public class AppFlowManager : Singleton<AppFlowManager>
{
    public bool IsPaused { get { return Time.timeScale == 0; } }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoToMenuAndSave()
    {
        GameStateManager.Instance.SaveToFile();
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
        GameStateManager.Instance.LoadFromFile();
        SceneManager.LoadScene("Game");
    }
}
