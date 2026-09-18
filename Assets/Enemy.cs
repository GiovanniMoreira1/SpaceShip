using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        // Movimento para esquerda
        float multiplier = 1f;

        if (SlowMotion.Instance != null)
        {
            multiplier = SlowMotion.Instance.speedMultiplier;
        }

        transform.Translate(
            Vector2.left *
            speed *
            multiplier *
            Time.deltaTime
        );

        // destroi ao sair da tela
        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // verifica se foi atingido por uma bala
        if (collision.CompareTag("Bullet"))
        {
            GameManager.Instance.AddScore(100);

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}