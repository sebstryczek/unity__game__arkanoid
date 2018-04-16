using System;

[Serializable]
public class State
{
    public int[][] fields;
    public Point ballPosition;
    public Point paddlePosition;
    public int lifes;
    public int score;
    public int timeFactor;
}