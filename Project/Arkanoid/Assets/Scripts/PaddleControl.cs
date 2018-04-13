using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    private Transform selfTransform;
    private float extremePosition;

    private void Awake()
    {
        this.selfTransform = this.transform;
        this.extremePosition = this.GetExtremePosition();
    }

    private void Update()
    {
        Vector2 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float posX = Mathf.Clamp(worldMousePosition.x, -this.extremePosition, this.extremePosition);
        this.transform.position = new Vector2(posX, this.transform.position.y);
    }

    private float GetExtremePosition()
    {
        float screenRatio = (float)Screen.width / Screen.height;
        float viewportHeight = Camera.main.orthographicSize * 2;
        float viewportWidth = viewportHeight * screenRatio;
        float halfViewportWidth = viewportWidth / 2;
        float halfPaddleWidth = this.selfTransform.localScale.x / 2;
        return halfViewportWidth - halfPaddleWidth;
    }
}
