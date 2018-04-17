using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public BrickType Type { get; private set; }
    public int Row { get; private set; }
    public int Column { get; private set; }
    
    public delegate void OnBrickDestroy(Brick brick);
    public event OnBrickDestroy onBrickDestroy;

    private void Awake()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    public void SetCoords(int row, int column)
    {
        this.Row = row;
        this.Column = column;
    }

    public void SetType(BrickType type)
    {
        this.Type = type;
        this.spriteRenderer.material.color = this.Type.Tint;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            this.onBrickDestroy(this);
            Destroy(this.gameObject);
        }
    }
}
