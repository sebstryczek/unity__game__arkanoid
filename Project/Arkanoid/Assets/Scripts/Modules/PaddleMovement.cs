using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    [SerializeField] private float speed = 4.0f;
    private float speedFactor = 1.0f;
    private Transform selfTransform;
    private float extremePosition;

    public void SetSpeedFactor(float speedFactor)
    {
        this.speedFactor = speedFactor;
    }

    private void Awake()
    {
        this.selfTransform = this.transform;
        this.extremePosition = this.GetExtremePosition();
    }

    private float GetExtremePosition()
    {
        float screenRatio = (float)Screen.width / Screen.height;
        float viewportHeight = Camera.main.orthographicSize * 2;
        float viewportWidth = viewportHeight * screenRatio;
        float halfViewportWidth = viewportWidth / 2;

        BoxCollider2D boxCollider2D = this.GetComponent<BoxCollider2D>();
        float halfPaddleWidth = boxCollider2D.bounds.extents.x;

        return halfViewportWidth - halfPaddleWidth;
    }

    private void Update()
    {
        if (AppFlowManager.Instance.IsPaused) return;
        
        Vector2 currentPosition = this.selfTransform.position;
        Vector2 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float targetPositionX = Mathf.Clamp(worldMousePosition.x, -this.extremePosition, this.extremePosition);

        float positionX = Mathf.Lerp(currentPosition.x, targetPositionX, Time.deltaTime * this.speed * this.speedFactor);
        this.selfTransform.position = new Vector2(positionX, currentPosition.y);

        GameStateManager.Instance.SetPaddlePosition(this.selfTransform.position);
    }
}
