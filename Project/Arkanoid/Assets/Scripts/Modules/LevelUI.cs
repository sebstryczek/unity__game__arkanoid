using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private List<Text> textLives;
    [SerializeField] private List<Text> textScore;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (AppFlowManager.Instance.IsPaused)
            {
                AppFlowManager.Instance.ContinueGame();
                this.pauseMenu.SetActive(false);
            }
            else
            {
                AppFlowManager.Instance.PauseGame();
                this.pauseMenu.SetActive(true);
            }
        }
    }

    public void SetLivesUI(int value)
    {
        this.textLives.ForEach(x => x.text = value.ToString());
    }

    public void SetScoreUI(int value)
    {
        this.textScore.ForEach(x => x.text = value.ToString());
    }
}
