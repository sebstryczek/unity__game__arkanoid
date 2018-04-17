using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BrickType", menuName = "ScriptableObject/BrickType", order = 1)]
public class BrickType : ScriptableObject
{
    [SerializeField] private int id = -1;
    public int Id { get { return this.id; } }

    [SerializeField] private Color tint = Color.white;
    public Color Tint { get { return this.tint; } }

    [SerializeField] private int points = 1;
    public int Points { get { return this.points; } }

    [SerializeField] private float speed = 1;
    public float Speed { get { return this.speed; } }

    [SerializeField] private float speedDuration = 0;
    public float SpeedDuration { get { return this.speedDuration; } }
    
    [SerializeField] private int bonusLives = 0;
    public int BonusLives { get { return this.bonusLives; } }
}
