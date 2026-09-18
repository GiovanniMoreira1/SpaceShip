using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Pontuação
    public int score = 0;
    public TMP_Text scoreText;

    // Vidas
    public int lives = 3;
    public TMP_Text livesText;

    // Game Over
    public GameObject gameOverPanel;
    public TMP_Text finalScoreText;

    // Slow Motion
    private bool slowMotionTriggered = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // Garante velocidade normal quando iniciar/reiniciar
        Time.timeScale = 1f;

        UpdateScoreText();
        UpdateLivesText();

        // Esconde Game Over
        gameOverPanel.SetActive(false);
    }

    public void AddScore(int points)
    {
        score += points;

        UpdateScoreText();

        if (score >= 500 && !slowMotionTriggered)
        {
            slowMotionTriggered = true;

            if (SlowMotion.Instance != null)
            {
                SlowMotion.Instance.ActivateSlowMotion();
            }
        }
    }

    public void LoseLife()
    {
        lives--;

        UpdateLivesText();

        if (lives <= 0)
        {
            GameOver();
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "SCORE: " + score;
    }

    void UpdateLivesText()
    {
        livesText.text = "VIDAS: " + lives;
    }

    void GameOver()
    {
        Debug.Log("GAME OVER!");

        // Mostra painel
        gameOverPanel.SetActive(true);

        // Mostra pontuação final
        finalScoreText.text = "PONTUAÇÃO: " + score;

        // Congela o jogo
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        // Volta o tempo ao normal
        Time.timeScale = 1f;

        // Recarrega a cena atual
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}