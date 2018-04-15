using System;
using UnityEngine;

[Serializable]
public class GameState
{
    //public Level level;
    public int[,] fields;
    public Vector2 ballPosition;
    public Vector3 paddlePosition;
    public int lifes;
    public int score;
    public int timeFactor;
}