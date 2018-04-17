using System;

[Serializable]
public class GameState
{
    public int[][] fields;
    public Point ballPosition;
    public Point paddlePosition;
    public int lives;
    public int score;
    public int timeFactor;
}
