using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Events;

public class GameStateManager : StorageManager<GameStateManager, GameState>
{
    public delegate void OnValueChange(int value);
    public event OnValueChange onSetLives;
    public event OnValueChange onSetScore;
    
    protected override void Awake()
    {
        this.fileName = "save.dat";
        base.Awake();
    }

    public float Level { get { return this.storage.State.level; } }
    public void SetLevel(float level)
    {
        this.storage.State.level = level;
    }

    public int[][] Fields { get { return this.storage.State.fields; } }
    public void SetFields(int[][] fields)
    {
        this.storage.State.fields = fields;
    }

    public bool IsBallReleased { get { return this.storage.State.isBallReleased; } }
    public void SetIsBallReleased(bool isBallReleased)
    {
        this.storage.State.isBallReleased = isBallReleased;
    }

    public Vector2 BallPosition
    {
        get
        {
            return new Vector2(this.storage.State.ballPosition.x, this.storage.State.ballPosition.y);
        }
    }
    public void SetBallPosition(Vector2 position)
    {
        this.storage.State.ballPosition = new Point(position.x, position.y);
    }

    public Vector2 BallVelocity
    {
        get
        {
            return new Vector2(this.storage.State.ballVelocity.x, this.storage.State.ballVelocity.y);
        }
    }
    public void SetBallVelocity(Vector2 velocity)
    {
        this.storage.State.ballVelocity = new Point(velocity.x, velocity.y);
    }

    public Vector2 PaddlePosition
    {
        get
        {
            return new Vector2(this.storage.State.paddlePosition.x, this.storage.State.paddlePosition.y);
        }
    }
    public void SetPaddlePosition(Vector2 position)
    {
        this.storage.State.paddlePosition = new Point(position.x, position.y);
    }

    public int Lives { get { return this.storage.State.lives; } }
    public void SetLives(int lives)
    {
        this.storage.State.lives = lives;
        if (this.onSetLives != null) this.onSetLives(lives);
    }

    public int Score { get { return this.storage.State.score; } }
    public void SetScore(int score)
    {
        this.storage.State.score = score;
        if (this.onSetScore != null) this.onSetScore(score);
    }

    public float SpeedFactor { get { return this.storage.State.speedFactor; } }
    public void SetSpeedFactor(float speedFactor)
    {
        this.storage.State.speedFactor = speedFactor;
    }

    public float SpeedFactorDuration { get { return this.storage.State.speedFactorDuration; } }
    public void SetSpeedFactorDuration(float speedFactorDuration)
    {
        this.storage.State.speedFactor = speedFactorDuration;
    }
}
