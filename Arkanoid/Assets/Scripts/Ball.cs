using UnityEngine;

public class Ball : MonoBehaviour
{
    public float initialSpeed = 8f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Launch();
    }

    void Launch()
    {
        Vector2 direction = Vector2.up;
        rb.linearVelocity = direction * initialSpeed;
    }
}
