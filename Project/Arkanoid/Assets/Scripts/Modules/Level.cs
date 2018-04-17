using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    [SerializeField] BallMovement ball;
    [SerializeField] Paddle paddle;
    private LevelBricks levelBricks;
    private LevelSpeed levelSpeed;
    private LevelStatus levelStatus;
    private LevelUI levelUI;
    
    private void Awake()
    {
        this.levelBricks = GetComponent<LevelBricks>();
        this.levelSpeed = GetComponent<LevelSpeed>();
        this.levelStatus = GetComponent<LevelStatus>();
        this.levelUI = GetComponent<LevelUI>();

        GameStateManager.Instance.onSetLives += this.levelUI.SetLivesUI;
        GameStateManager.Instance.onSetScore += this.levelUI.SetScoreUI;
    }

    private void OnDestroy()
    {
        GameStateManager.Instance.onSetLives -= this.levelUI.SetLivesUI;
        GameStateManager.Instance.onSetScore -= this.levelUI.SetScoreUI;
    }

    private void Start()
    {
        /* In build, state is created in menu */
        if (Application.isEditor && !GameStateManager.Instance.IsStateExist)
        {
            GameStateManager.Instance.Create();
        }
        /* *** */

        if (GameStateManager.Instance.Fields != null)
        {
            this.ContinueLevel();
        }
        else
        {
            this.CreateFirstLevel();
        }
    }

    private void ContinueLevel()
    {
        this.levelUI.SetLivesUI(GameStateManager.Instance.Lives);
        this.levelUI.SetScoreUI(GameStateManager.Instance.Score);

        this.paddle.LoadState();
        this.ball.LoadState();
        this.ball.SetLevelSpeed(GameStateManager.Instance.Level);
        this.levelSpeed.SetSpeed(GameStateManager.Instance.SpeedFactor, GameStateManager.Instance.SpeedFactorDuration);
        this.levelBricks.CreateBricks(GameStateManager.Instance.Fields, this.OnBrickHitted);
    }

    private void CreateFirstLevel()
    {
        int[][] fields = this.levelBricks.GetRandomFieldsSet();
        GameStateManager.Instance.SetFields(fields);
        GameStateManager.Instance.SetLevel(1);
        GameStateManager.Instance.SetLives(3);
        GameStateManager.Instance.SetScore(0);
        GameStateManager.Instance.SetSpeedFactor(1);
        GameStateManager.Instance.SetSpeedFactorDuration(0);

        this.ball.SetLevelSpeed(GameStateManager.Instance.Level);
        this.paddle.CaptureBall();
        this.levelSpeed.SetSpeed(GameStateManager.Instance.SpeedFactor, GameStateManager.Instance.SpeedFactorDuration);
        this.levelBricks.CreateBricks(GameStateManager.Instance.Fields, this.OnBrickHitted);
    }

    private void CreateNextLevel()
    {
        int[][] fields = this.levelBricks.GetRandomFieldsSet();
        GameStateManager.Instance.SetLevel(GameStateManager.Instance.Level + 1);
        GameStateManager.Instance.SetFields(fields);
        GameStateManager.Instance.SetSpeedFactor(1);
        GameStateManager.Instance.SetSpeedFactorDuration(0);

        this.ball.SetLevelSpeed(GameStateManager.Instance.Level);
        this.paddle.CaptureBall();
        this.levelSpeed.ResetSpeed();
        this.levelBricks.CreateBricks(GameStateManager.Instance.Fields, this.OnBrickHitted);
    }

    private void OnBrickHitted(Brick brick)
    {
        GameStateManager.Instance.Fields[brick.Row][brick.Column] = -1;
        GameStateManager.Instance.SetScore(GameStateManager.Instance.Score + brick.Type.Points);
        GameStateManager.Instance.SetLives(GameStateManager.Instance.Lives + brick.Type.BonusLives);
        GameStateManager.Instance.SetSpeedFactor(brick.Type.SpeedFactor);
        GameStateManager.Instance.SetSpeedFactorDuration(brick.Type.SpeedFactorDuration);
        this.levelSpeed.SetSpeed(brick.Type.SpeedFactor, brick.Type.SpeedFactorDuration);

        if (this.levelStatus.IsLevelComplete())
        {
            this.CreateNextLevel();
        }
    }
}
