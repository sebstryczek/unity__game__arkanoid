using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private BallMovement ball;
    public bool isBallReleased = false;
    private Transform selfTransform;

    private void Awake()
    {
        this.selfTransform = this.transform;
    }

    private void Update()
    {
        if (AppFlowManager.Instance.IsPaused) return;

        if (!this.isBallReleased && Input.GetMouseButtonUp(0))
        {
            this.ReleaseBall();
        }
    }

    public void LoadState()
    {
        this.selfTransform.position = GameStateManager.Instance.PaddlePosition;
        if (GameStateManager.Instance.IsBallReleased)
        {
            this.ReleaseBall();
        }
    }

    public void CaptureBall()
    {
        this.ball.Stop();
        this.ball.transform.SetParent(this.selfTransform);
        this.ball.transform.localPosition = new Vector2(0, 1.1f);
        this.isBallReleased = false;
        GameStateManager.Instance.SetIsBallReleased(this.isBallReleased);
    }

    public void ReleaseBall()
    {
        this.ball.transform.SetParent(null);
        this.ball.Push();
        this.isBallReleased = true;
        GameStateManager.Instance.SetIsBallReleased(this.isBallReleased);
    }
}
