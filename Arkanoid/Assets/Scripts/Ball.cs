using UnityEngine;

public class Ball : MonoBehaviour
{
    public float initialSpeed = 8f;
    public KeyCode starter = KeyCode.Space;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {

        if (Input.GetKey(starter) && rb.linearVelocity.magnitude == 0)
        {
            Launch();
        }
    }

    void Launch()
    {
        Vector2 direction = new Vector2(
            Random.Range(-0.5f, 0.5f),
            1f
            ).normalized;
        rb.linearVelocity = direction * initialSpeed;
    }
}
