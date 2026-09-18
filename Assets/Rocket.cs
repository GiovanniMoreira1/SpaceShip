using UnityEngine;
using UnityEngine.InputSystem;

public class Rocket : MonoBehaviour
{
    public Sprite[] flameStates;
    private SpriteRenderer sr;

    public GameObject bulletPrefab;
    public Transform firePoint;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Atirar
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Shoot();
        }

        // Alterar potência do foguete
        if (Keyboard.current.wKey.wasPressedThisFrame)
            SetThrustLevel(0);

        if (Keyboard.current.aKey.wasPressedThisFrame)
            SetThrustLevel(1);

        if (Keyboard.current.sKey.wasPressedThisFrame)
            SetThrustLevel(2);

        if (Keyboard.current.dKey.wasPressedThisFrame)
            SetThrustLevel(3);
    }

    void Shoot()
    {
        Debug.Log("Nave: " + transform.position);
        Debug.Log("FirePoint: " + firePoint.position);

        GameObject bullet = Instantiate(
            bulletPrefab,
            firePoint.position,
            Quaternion.identity
        );

        Debug.Log("Bullet criada em: " + bullet.transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Nave atingida!");

            GameManager.Instance.LoseLife();

            Destroy(collision.gameObject);
        }
    }

    public void SetThrustLevel(int estagio)
    {

        sr.sprite = flameStates[estagio];

        Parallax.thrustMultiplier = 1f + (estagio * 0.8f);
    }
}