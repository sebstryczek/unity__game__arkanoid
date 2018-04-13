using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private float speed = 5.0f;

    private void Start()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = Vector2.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }
}
