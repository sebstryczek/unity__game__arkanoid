using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    private float levelSpeed = 0.0f;
    private float speedFactor = 1.0f;

    private new Rigidbody2D rigidbody2D;
    private Transform selfTransform;

    private void Awake()
    {
        this.rigidbody2D = GetComponent<Rigidbody2D>();
        this.selfTransform = this.transform;
    }

    private void Update()
    {
        GameStateManager.Instance.SetBallPosition(this.selfTransform.position);
        GameStateManager.Instance.SetBallVelocity(this.rigidbody2D.velocity);
    }

    public void LoadState()
    {
        this.selfTransform.position = GameStateManager.Instance.BallPosition;
        this.rigidbody2D.velocity =  GameStateManager.Instance.BallVelocity;
    }

    public void SetLevelSpeed(float levelSpeed)
    {
        this.levelSpeed = levelSpeed;
        if (this.rigidbody2D.velocity.sqrMagnitude > 0)
        {
            this.UpdateVelocity();
        }
    }

    public void SetSpeedFactor(float speedFactor)
    {
        this.speedFactor = speedFactor;
        if (this.rigidbody2D.velocity.sqrMagnitude > 0)
        {
            this.UpdateVelocity();
        }
    }
    
    public void Stop()
    {
        this.rigidbody2D.velocity = Vector2.zero;
    }

    public void Push()
    {
        this.rigidbody2D.velocity = Vector2.up * (this.speed + this.levelSpeed) * this.speedFactor;
    }

    private void UpdateVelocity()
    {
        this.rigidbody2D.velocity = this.rigidbody2D.velocity.normalized * (this.speed + this.levelSpeed) * this.speedFactor;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Paddle"))
        {
            Vector2 pos = this.transform.position;
            Vector2 paddlePos = other.transform.position;
            float paddleSize = other.collider.bounds.size.x;

            float dirX = (pos.x - paddlePos.x) / (paddleSize / 2);
            Vector2 dir = new Vector2(dirX, 1).normalized;

            this.rigidbody2D.velocity = dir * (this.speed + this.levelSpeed) * this.speedFactor;
        }
    }
}
