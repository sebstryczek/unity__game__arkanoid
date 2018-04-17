using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Events;

public class GameStateManager : Singleton<GameStateManager>
{
    private string fileName = "save.dat";
    private Storage<GameState> storage;
    public GameState State { get { return this.storage.State; } }
    public bool IsStateExist { get { return this.State != null; } }

    public delegate void OnValueChange(int value);
    public event OnValueChange onSetLives;
    public event OnValueChange onSetScore;

    private void Awake()
    {
        this.storage = new Storage<GameState>(fileName);
    }

    public void Create()
    {
        this.storage.Create();
    }

    public void Save()
    {
        this.storage.Save();
    }

    public void Load()
    {
        this.storage.Load();
    }

    public void SetFields(int[][] fields)
    {
        this.State.fields = fields;
    }

    public void SetBallPosition(Vector2 position)
    {
        this.State.ballPosition = new Point(position.x, position.y);
    }

    public void SetPaddlePosition(Vector2 position)
    {
        this.State.paddlePosition = new Point(position.x, position.y);
    }

    public void SetLives(int lives)
    {
        this.State.lives = lives;
        if (this.onSetLives != null) this.onSetLives(lives);
    }

    public void SetScore(int score)
    {
        this.State.score = score;
        if (this.onSetScore != null) this.onSetScore(score);
    }

    public void SetTimeFactor(int timeFactor)
    {
        this.State.timeFactor = timeFactor;
    }
}
