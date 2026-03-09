using UnityEngine;

public class playerControl : MonoBehaviour
{
    public KeyCode moveLeft = KeyCode.H;
    public KeyCode moveRight = KeyCode.L;
    public KeyCode shootKey = KeyCode.Space;

    public float speed = 10.0f;
    public float boundX = 2.25f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    private Rigidbody2D rb2d;

    private GameObject currentBullet;

    Animator anim;
    bool isDead = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Shoot();
    }

    void Move()
    {
        var vel = rb2d.linearVelocity;

        if (Input.GetKey(moveLeft))
        {
            vel.x = -speed;
        }
        else if (Input.GetKey(moveRight))
        {
            vel.x = speed;
        }
        else
        {
            vel.x = 0;
        }

        rb2d.linearVelocity = vel;

        var pos = transform.position;

        if (pos.x > boundX)
        {
            pos.x = boundX;
        }
        else if (pos.x < -boundX)
        {
            pos.x = -boundX;
        }

        transform.position = pos;
    }

    void Shoot()
    {
        if (Input.GetKeyDown(shootKey) && currentBullet == null)
        {
            currentBullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            currentBullet.GetComponent<Bullet>().player = this;
        }
    }

    public void BulletDestroyed()
    {
        currentBullet = null;
    }

    public void Die()
    {
        if (isDead) return;

        isDead = true;
        Debug.Log("Player morreu - trigger Damage");
        rb2d.linearVelocity = Vector2.zero;
        anim.SetTrigger("Damage");

        Invoke("GameOver", 1f);
    }

    void GameOver()
    {
        FindObjectOfType<GameManager>().GameOver();
        Destroy(gameObject);
        // Debug.Log("Game Over");
    }
}
