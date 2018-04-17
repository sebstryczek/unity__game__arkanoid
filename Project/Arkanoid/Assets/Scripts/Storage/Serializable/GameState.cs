using System;

[Serializable]
public class GameState
{
    public float level;
    public int[][] fields;
    public bool isBallReleased;
    public Point ballPosition;
    public Point ballVelocity;
    public Point paddlePosition;
    public int lives;
    public int score;
    public float speedFactor;
    public float speedFactorDuration;
}
