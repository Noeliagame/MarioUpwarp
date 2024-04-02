using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlatform : MonoBehaviour
{
    public float moveDistance = 0.1f; // Distancia a mover hacia abajo
    public float moveSpeed = 2f; // Velocidad de movimiento

    private Vector2 initialPosition; // Posición inicial
    private bool isPlayerOnPlatform = false; // Flag para verificar si el jugador está en la plataforma

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        // Si el jugador está en la plataforma, mover la plataforma hacia abajo
        if (isPlayerOnPlatform)
        {
            Vector2 targetPosition = new Vector2(initialPosition.x, initialPosition.y - moveDistance);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        else // Si el jugador no está en la plataforma, volver a su posición inicial
        {
            transform.position = Vector2.MoveTowards(transform.position, initialPosition, moveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnPlatform = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnPlatform = false;
        }
    }
}
