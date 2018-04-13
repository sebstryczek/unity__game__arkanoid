using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    [SerializeField] private Transform topBorder;
    [SerializeField] private Transform leftBorder;
    [SerializeField] private Transform rightBorder;

    private void Awake()
    {
        float screenRatio = (float)Screen.width / Screen.height;
        float viewportHeight = Camera.main.orthographicSize * 2;
        float viewportWidth = viewportHeight * screenRatio;
        float halfViewportHeight = viewportHeight / 2;
        float halfViewportWidth = viewportWidth / 2;

        this.topBorder.position = new Vector2(0, halfViewportHeight);
        this.topBorder.localScale = new Vector2(viewportWidth, this.topBorder.localScale.y);

        this.leftBorder.position = new Vector2(-halfViewportWidth, 0);
        this.leftBorder.localScale = new Vector2(this.leftBorder.localScale.x, viewportHeight);

        this.rightBorder.position = new Vector2(halfViewportWidth, 0);
        this.rightBorder.localScale = new Vector2(this.rightBorder.localScale.x, viewportHeight);
    }
}