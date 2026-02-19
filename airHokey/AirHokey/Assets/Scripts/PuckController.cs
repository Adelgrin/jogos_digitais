using UnityEngine;

public class PuckController : MonoBehaviour
{
    public float hitForce = 10f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 direction = (transform.position - collision.transform.position).normalized;
            rb.linearVelocity = direction * hitForce;
        }
    }
}
