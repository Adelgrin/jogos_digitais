using UnityEngine;

public class Block : MonoBehaviour
{
    public int health = 2;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnDestroy()
    {
        FindObjectOfType<GameManager>().BlockDestroyed();
    }
}
