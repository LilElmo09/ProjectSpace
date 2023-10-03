using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoObstaculo : MonoBehaviour
{
    public float velocidad = 1f; // Velocidad de movimiento
    public float tiempoDeVida = 5f; // Tiempo de vida en segundos
    public Sprite[] sprites; // Array que contiene los sprites posibles
    public float minRotationSpeed = -10f; // Velocidad mínima de rotación
    public float maxRotationSpeed = 10f; // Velocidad máxima de rotación

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D myRigidbody; // Renombrado a "myRigidbody"
    private CircleCollider2D circleCollider;
    private float rotationSpeed;

    private GameObject Jugador;
    private Puntuacion scriptPuntiacion;

    private void Start()
    {
        // Obtener el componente Rigidbody2D
        myRigidbody = GetComponent<Rigidbody2D>(); // Actualizado a "myRigidbody"

        // Destruir el objeto después de tiempoDeVida segundos
        Destroy(gameObject, tiempoDeVida);

        // Obtén la referencia al componente SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();

        // Cambia el sprite inicial y ajusta el collider
        CambiarSpriteAleatorio();

        // Generar una velocidad de rotación aleatoria dentro del rango
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);

        GameObject Jugador = GameObject.Find("Jugador");
        scriptPuntiacion = Jugador.GetComponent<Puntuacion>();
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        // Calcular el vector de movimiento
        Vector2 movimiento = new Vector2(0f, -velocidad) * Time.fixedDeltaTime;

        // Aplicar el movimiento al Rigidbody2D
        myRigidbody.MovePosition((Vector2)transform.position + movimiento); // Actualizado a "myRigidbody"
    }

    private void CambiarSpriteAleatorio()
    {
        // Genera un índice aleatorio dentro del rango de la lista de sprites
        int randomIndex = Random.Range(0, sprites.Length);

        // Asigna el sprite aleatorio al componente SpriteRenderer
        spriteRenderer.sprite = sprites[randomIndex];

        // Obtén el tamaño del sprite
        float spriteSize = Mathf.Max(spriteRenderer.bounds.size.x, spriteRenderer.bounds.size.y);

        // Ajusta el radio del collider al tamaño del sprite
        circleCollider.radius = spriteSize / 2f;
    }
    
    public void OnTriggerEnter2D(Collider2D collisionBala)
    {
        if(collisionBala.gameObject.CompareTag("Bala"))
        {

            scriptPuntiacion.AlDestruirAsteroide();
            Destroy(collisionBala.gameObject);
            Destroy(this.gameObject);
        }
    }
}