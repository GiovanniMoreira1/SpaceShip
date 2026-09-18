using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class SlowMotion : MonoBehaviour
{
    public static SlowMotion Instance;

    public float speedMultiplier = 1f;
    public float slowMultiplier = 0.3f;
    public float duration = 5f;

    private bool active = false;

    void Awake()
    {
        Instance = this;
    }

    public void ActivateSlowMotion()
    {
        if (!active)
        {
            StartCoroutine(SlowRoutine());
        }
    }

    void Update()
{
    if (Keyboard.current.leftShiftKey.wasPressedThisFrame)
    {
        ActivateSlowMotion();
    }
}

    IEnumerator SlowRoutine()
    {
        active = true;

        Debug.Log("SLOW MOTION ATIVADO!");

        // 30% da velocidade normal
        speedMultiplier = slowMultiplier;

        // Espera 5 segundos
        yield return new WaitForSeconds(duration);

        // Volta ao normal
        speedMultiplier = 1f;

        active = false;

        Debug.Log("SLOW MOTION FINALIZADO!");
    }
}