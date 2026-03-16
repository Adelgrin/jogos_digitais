using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 8f;

    float minX;
    float maxX;

    void Start()
    {
        Camera cam = Camera.main;

        float halfWidth = GetComponent<SpriteRenderer>().bounds.extents.y;

        minX = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + halfWidth;
        maxX = cam.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - halfWidth;
    }

    void Update()
    {
        float move = 0;

        if (Input.GetKey(KeyCode.J)) move -= 1;
        if (Input.GetKey(KeyCode.K)) move += 1;

        transform.Translate(Vector2.up * move * speed * Time.deltaTime);

        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, minX, maxX);

        transform.position = pos;
    }
}
