using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelStatus : MonoBehaviour
{
    [SerializeField] private UnityEvent onGameOver;

    public void BallLost()
    {
        GameStateManager.Instance.SetLives(GameStateManager.Instance.Lives - 1);
    
        if (GameStateManager.Instance.Lives < 1)
        {
            this.GameOver();
        }
    }

    private void GameOver()
    {
        GameStateManager.Instance.RemoveFile();
        this.onGameOver.Invoke();
    }

    public bool IsLevelComplete()
    {
        int[][] fields = GameStateManager.Instance.Fields;
        for (int i = 0; i < fields.Length; i++)
        {
            for (int j = 0; j < fields[i].Length; j++)
            {
                if (fields[i][j] > -1)
                {
                    return false;
                }
            }
        }

        return true;
    }
}
