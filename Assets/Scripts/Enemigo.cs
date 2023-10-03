using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{   
    public Transform target;

    public float tiempoVidaEnemigo;
    public float velocidadBala;
    private float intervaloDisparo;
    private float tiempoVidaBala;
    private float tiempoUltimoDisparo;
    private float velocidadMovimiento;

    public GameObject balaPrefab;
    public GameObject balaMadre; 

    public float numeroCaso;
    public float Y;
    public float X;
    public float distancia;
    private Vector3 posicionInicio;
    private Vector3 posicionFinal;
    private bool moviendoabajo;

    // Start is called before the first frame update
    void Start()
    {
        tiempoVidaEnemigo = 8.5f;
        velocidadBala = 1;
        intervaloDisparo = 1.5f;
        tiempoVidaBala = 7;
        velocidadMovimiento = 0.5f;
        distancia = 7f;

        target = GameObject.Find("Jugador").transform;
        balaMadre = GameObject.Find("Cargador");

        switch (numeroCaso)
        {
            case 0:
                transform.position = new Vector3(-0.59f, 2, 0);
                posicionFinal = new Vector3(-0.59f, 0, 0);
                break;
            case 1:
                transform.position = new Vector3(0, 2, 0);
                posicionFinal = new Vector3(0, 0, 0);
                break;
            case 2:
                transform.position = new Vector3(0.59f, 2, 0);
                posicionFinal = new Vector3(0.59f, 0, 0);
                break;
            case 3:
                transform.position = new Vector3(-1.108912f, 2, 0);
                posicionFinal = new Vector3(0, 0.22f, 0);
                break;
            case 4:
                transform.position = new Vector3(1.108912f, 2, 0);
                posicionFinal = new Vector3(0, 0.22f, 0);
                break;
            case 5:
                transform.position = new Vector3(-1.5f, 0, 0);
                break;
            case 6:
                transform.position = new Vector3(1.5f, 0, 0);
                break;
            default:
                break;
        }
        posicionInicio = transform.position;
    }

    private void FixedUpdate()
    {
        Rotacion();
        if (Time.time - tiempoUltimoDisparo >= intervaloDisparo)
        {
            Disparo();
            tiempoUltimoDisparo = Time.time;
        }
        switch (numeroCaso)
        {
            case 5:
                MovimientoTipo1();
                break;
            case 6:
                MovimientoTipo2();
                break;
            default:
                MovimentoTipo0();
                break;
        }
    }

    void Disparo()
    {
        // Crea una instancia de la bala, establece su posición y dirección de movimiento
        GameObject bala = Instantiate(balaPrefab, transform.position, transform.rotation);
        Vector3 direccion = (target.position - transform.position).normalized;
        bala.GetComponent<Rigidbody2D>().velocity = direccion * velocidadBala;
        bala.transform.SetParent(balaMadre.transform);
        bala.name = "BalaEnemigo";
        Destroy(bala, tiempoVidaBala);
    }

    void Rotacion()
    {
        // Rotacion segun la posicion de jugador
        if (target != null)
        {
            // Calcula la dirección hacia el objetivo
            Vector3 direction = target.position - transform.position;
            direction.z = 0f;
            direction.Normalize();

            // Calcula el ángulo de rotación en radianes y luego lo convierte a grados
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Rota el objeto solo en el eje Z hacia el ángulo deseado
            transform.rotation = Quaternion.Euler(0f, 0f, (angle - 90));
        }
    }

    public void OnTriggerEnter2D(Collider2D collisionBala)
    {
        if(collisionBala.gameObject.CompareTag("Bala"))
        {
            Destroy(collisionBala.gameObject);
            Destroy(this.gameObject);
            target.GetComponent<Puntuacion>().MatarEnemigo();
        }
    }
    public void MovimentoTipo0()
    {
        transform.position = Vector3.MoveTowards(transform.position, posicionFinal, velocidadMovimiento * Time.deltaTime);

        if (transform.position == posicionFinal)
        {
            moviendoabajo = !moviendoabajo;
            posicionFinal = moviendoabajo ? posicionInicio : posicionInicio + Vector3.down * distancia;
        }
        Destroy(this.gameObject, tiempoVidaEnemigo);
    }

    public void MovimientoTipo1()
    {
        Y = 1 + Mathf.Sin(Time.time * 5f) * 0.48f;
        X = X + velocidadMovimiento;

        Vector3 nuevaPosicion = new Vector3(X, Y, 0);
        transform.position = Vector3.MoveTowards(transform.position, nuevaPosicion, Time.deltaTime * velocidadMovimiento);

        Destroy(gameObject, 5f);
    }

    public void MovimientoTipo2()
    {
        Y = 1 + Mathf.Sin(Time.time * 5f) *  0.48f;
        X = X - velocidadMovimiento;

        Vector3 nuevaPosicion = new Vector3(X, Y, 0);
        transform.position = Vector3.MoveTowards(transform.position, nuevaPosicion, Time.deltaTime * velocidadMovimiento);

        Destroy(gameObject, 5f);
    }
}