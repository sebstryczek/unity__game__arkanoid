using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    private new Rigidbody2D rigidbody2D;

    private void Start()
    {
        this.rigidbody2D = GetComponent<Rigidbody2D>();
        this.rigidbody2D.velocity = Vector2.up * speed;
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

            this.rigidbody2D.velocity = dir * speed;
        }
    }
}
