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

    [SerializeField] private float speedFactor = 1;
    public float SpeedFactor { get { return this.speedFactor; } }

    [SerializeField] private float speedFactorDuration = 0;
    public float SpeedFactorDuration { get { return this.speedFactorDuration; } }
    
    [SerializeField] private int bonusLives = 0;
    public int BonusLives { get { return this.bonusLives; } }
}
