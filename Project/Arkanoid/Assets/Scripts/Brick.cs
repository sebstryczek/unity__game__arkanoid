using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private BrickType type;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    public void SetType(BrickType type)
    {
        this.type = type;
        this.spriteRenderer.material.color = this.type.Tint;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Destroy(this.gameObject);
        }
    }
}