using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if(transform.position.x > 20)
        {
            Destroy(gameObject);
        }
    }
}