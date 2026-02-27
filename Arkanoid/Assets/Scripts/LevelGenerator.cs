using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject blockPrefab;

    public int rows = 6;
    public int cols = 10;

    public float blockSpacing = 1.1f;

    public float spawnChance = 0.7f; // 70% de chance de gerar bloco

    public float offsetX = 8;
    public float offsetY = 5;

    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                if (Random.value < spawnChance)
                {
                    Vector2 position = new Vector2(
                        x * blockSpacing - offsetX,
                        -y * blockSpacing + offsetY
                    );

                    Instantiate(blockPrefab, position, Quaternion.identity);
                }
            }
        }
    }
}
