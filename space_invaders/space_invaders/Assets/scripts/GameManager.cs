using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
    bool gameOver = false;

    void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }

        CheckAliens();
    }

    void CheckAliens()
    {
        GameObject[] aliens = GameObject.FindGameObjectsWithTag("Alien");
        // Debug.Log(aliens);

        if (aliens.Length == 0)
        {
            RestartGame();
        }
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverText.SetActive(true);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
