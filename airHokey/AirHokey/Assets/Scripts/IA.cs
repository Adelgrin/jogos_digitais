using UnityEngine;

public class IA : MonoBehaviour
{
    public Transform puck_0;
    public float speed = 5f;

    void Update()
    {
        Vector3 targetPosition = transform.position;

        // Segue apenas o eixo X
        targetPosition.x = puck_0.position.x;

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            speed * Time.deltaTime
        );
    }
}

