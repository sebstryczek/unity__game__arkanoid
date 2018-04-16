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

}