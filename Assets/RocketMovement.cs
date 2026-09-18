using UnityEngine;
using UnityEngine.InputSystem;

public class RocketMovement : MonoBehaviour
{
    public float speed = 5f;

    public float minX = -4f;
    public float maxX = 4f;
    public float minY = -4f;
    public float maxY = 4f;

    void Update()
    {
        Vector2 direction = Vector2.zero;

        if (Keyboard.current.wKey.isPressed)
            direction.y += 1;

        if (Keyboard.current.sKey.isPressed)
            direction.y -= 1;

        if (Keyboard.current.aKey.isPressed)
            direction.x -= 1;

        if (Keyboard.current.dKey.isPressed)
            direction.x += 1;

        direction = direction.normalized;

        transform.Translate(direction * speed * Time.deltaTime);

        Vector3 position = transform.position;

        position.x = Mathf.Clamp(position.x, minX, maxX);
        position.y = Mathf.Clamp(position.y, minY, maxY);

        transform.position = position;
    }
}