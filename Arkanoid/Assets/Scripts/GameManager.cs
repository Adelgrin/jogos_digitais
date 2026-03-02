using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
    public float restartDelay = 3f;
    public KeyCode skipper = KeyCode.N;

    int totalBlocks;

    void Start()
    {
        totalBlocks = FindObjectsOfType<Block>().Length;
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
        Invoke(nameof(RestartLevel), restartDelay);
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BlockDestroyed()
    {
        totalBlocks--;

        if (totalBlocks <= 0)
        {
            Invoke(nameof(LoadNextLevel), 2f);
        }
    }

    void LoadNextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex + 1);
    }
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKey(skipper))
        {
            LoadNextLevel();
        }
#endif
    }
}
