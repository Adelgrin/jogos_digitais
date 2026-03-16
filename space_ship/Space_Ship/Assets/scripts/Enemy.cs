// using UnityEngine;
//
// public class Enemy : MonoBehaviour
// {
//     public float speed = 3f;
//     public int scoreValue = 100;
//
//     void Update()
//     {
//         // transform.Translate(Vector2.left * speed * Time.deltaTime);
//         float speedFinal = speed * EnemyManager.instance.speedMultiplier;
//         Debug.Log(speedFinal);
//
//         transform.Translate(Vector2.left * speedFinal * Time.deltaTime);
//     }
//
//     void OnTriggerEnter2D(Collider2D other)
//     {
//         // inimigo atingido pelo projétil
//         if (other.CompareTag("Projectile"))
//         {
//             ScoreManager.instance.AddScore(scoreValue);
//
//             Destroy(other.gameObject);
//             Destroy(gameObject);
//             FindFirstObjectByType<ItemSpawner>().TrySpawn(transform.position);
//         }
//
//         // inimigo colidiu com player
//         if (other.CompareTag("Player"))
//         {
//             Destroy(other.gameObject);
//             Destroy(gameObject);
//         }
//     }
//
//     void OnBecameInvisible()
//     {
//         Destroy(gameObject);
//     }
// }
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public int scoreValue = 100;

    void Update()
    {
        float multiplier = 1f;

        if (EnemyManager.instance != null)
            multiplier = EnemyManager.instance.speedMultiplier;

        transform.Translate(Vector2.left * speed * multiplier * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // inimigo atingido pelo projétil
        if (other.CompareTag("Projectile"))
        {
            // adiciona pontuação
            ScoreManager.instance.AddScore(scoreValue);

            // tenta gerar item
            ItemSpawner spawner = FindAnyObjectByType<ItemSpawner>();

            if (spawner != null)
            {
                spawner.TrySpawn(transform.position);
            }

            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        // colisão com player
        if (other.CompareTag("Player"))
        {
            GameManager.instance.GameOver();

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
