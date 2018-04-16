using UnityEngine;
using UnityEngine.SceneManagement;

public class AppManager : Singleton<AppManager>
{
    public void NewGame()
    {
        StateManager.Instance.CreateEmptyState();
        SceneManager.LoadScene("Game");
    }

    public void ContinueGame()
    {
        StateManager.Instance.LoadState();
        SceneManager.LoadScene("Game");
    }

    public void Leaderboard()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}