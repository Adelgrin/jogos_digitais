using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    public float speedMultiplier = 1f;

    void Awake()
    {
        instance = this;
    }

    public void SlowEnemies(float multiplier, float duration)
    {
        StartCoroutine(SlowCoroutine(multiplier, duration));
    }

    IEnumerator SlowCoroutine(float multiplier, float duration)
    {
        speedMultiplier = multiplier;

        yield return new WaitForSeconds(duration);

        speedMultiplier = 1f;
    }
}
