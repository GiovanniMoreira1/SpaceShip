using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float lenght;
    public float parallaxEffect;
    public static float thrustMultiplier = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
       
    }

    // Update is called once per frame
    void Update()
    {
        float multiplier = 1f;

        if (SlowMotion.Instance != null)
        {
            multiplier = SlowMotion.Instance.speedMultiplier;
        }

        float speed =
            parallaxEffect *
            thrustMultiplier *
            multiplier;
            
        transform.position += Vector3.left * Time.deltaTime * speed;

        transform.position += Vector3.left * Time.deltaTime * parallaxEffect;
            if(transform.position.x < -lenght ) {
                transform.position = new Vector3(lenght, transform.position.y, transform.position.z);
            }
    }
}
