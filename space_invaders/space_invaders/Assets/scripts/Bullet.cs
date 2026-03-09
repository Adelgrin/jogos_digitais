using UnityEngine;

public class Bullet : MonoBehaviour
{
    public playerControl player;
    public float speed = 10f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Bullet collided with: {collision.gameObject.name} (tag={collision.gameObject.tag})");
        if (collision.gameObject.CompareTag("Alien"))
        {
            Destroy(collision.gameObject);
        }
        DestroyBullet();
    }

    void OnBecameInvisible()
    {
        DestroyBullet();
    }

    void DestroyBullet()
    {
        if (player != null)
            player.BulletDestroyed();
        Destroy(gameObject);
    }
}
