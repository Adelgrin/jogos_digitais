using UnityEngine;

public class BulletAlien : MonoBehaviour
{
    // public playerControl player;
    public float speed = 6f;
    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log($"Bullet collided with: {collision.gameObject.name} (tag={collision.gameObject.tag})");
        // if (collision.gameObject.CompareTag("Alien"))
        // {
        // Destroy(collision.gameObject);
        // }
        if (collision.gameObject.CompareTag("Player"))
        {
            playerControl player = collision.gameObject.GetComponent<playerControl>();

            if (player != null)
            {
                player.Die();
            }

            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // void DestroyBullet()
    // {
    //      if (player != null)
    //          player.BulletDestroyed();
    //     Destroy(gameObject);
    // }
}
