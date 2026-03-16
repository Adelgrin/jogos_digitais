using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject gameOverUI;

    bool gameOver = false;

    void Awake()
    {
        instance = this;
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverUI.SetActive(true);
    }

    void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
