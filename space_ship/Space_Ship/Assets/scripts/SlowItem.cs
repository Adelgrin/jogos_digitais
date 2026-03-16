using UnityEngine;

public class SlowItem : MonoBehaviour
{
    public float speed = 2f;
    public float slowMultiplier = 0.4f;
    public float duration = 5f;

    void Update()
    {
        // move o item para a esquerda
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            EnemyManager.instance.SlowEnemies(slowMultiplier, duration);
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
