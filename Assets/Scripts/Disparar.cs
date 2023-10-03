using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    public GameObject balaPrefab;               // El prefab de la bala que se va a disparar
    public float velocidadBala = 20f;           // Velocidad de la bala
    public float tiempoEntreDisparos = 0.5f;    // Tiempo en segundos entre cada disparo
    public float tiempoDeVida = 5f;             // Tiempo en segundos que durará la bala antes de desaparecer
    
    private float tiempoSiguienteDisparo;       // El momento en que se podrá disparar la siguiente bala
    private GameObject balaPadre;                // Padre del obstáculo
    private SpriteRenderer rend;                // Render de la bala
    private Puntuacion puntuacionReference;

    void Start()
    {
        balaPadre = GameObject.Find("Cargador");
        puntuacionReference = GetComponent<Puntuacion>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > tiempoSiguienteDisparo)
        {
            tiempoSiguienteDisparo = Time.time + tiempoEntreDisparos;

            GameObject nuevaBala = Instantiate(balaPrefab, transform.position, Quaternion.identity);
            nuevaBala.name = "BalaJugador";
            rend = nuevaBala.GetComponent<SpriteRenderer>();

            Rigidbody2D rigidbodyBala = nuevaBala.GetComponent<Rigidbody2D>();
            nuevaBala.transform.SetParent(balaPadre.transform);
            rigidbodyBala.velocity = Vector2.up * velocidadBala;
            puntuacionReference.BajaPorDisparar();
            Destroy(nuevaBala, tiempoDeVida);
        }
    }
}
