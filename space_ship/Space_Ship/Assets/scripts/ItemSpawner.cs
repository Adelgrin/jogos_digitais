using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab;
    public float spawnChance = 0.1f;

    public void TrySpawn(Vector3 position)
    {
        if(Random.value < spawnChance)
        {
            Instantiate(itemPrefab, position, Quaternion.identity);
        }
    }
}
