using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    public float velocidad; // Velocidad de movimiento del fondo
    public float tiempoParaCopia; // Tiempo para crear una copia del fondo
    public Vector3 spawnPosition; // Coordenada donde se generará la copia del fondo

    private Renderer backgroundRenderer;
    private float backgroundHeight;
    private float tiempoCopia; // Tiempo actual para la creación de una copia
    private bool copiaCreada; // Bandera para verificar si se ha creado la copia
    private GameObject fondoPadre;

    private void Start()
    {
        // Obtener el componente Renderer y calcular la altura del fondo
        backgroundRenderer = GetComponent<Renderer>();
        backgroundHeight = backgroundRenderer.bounds.size.y;

        tiempoCopia = tiempoParaCopia;
        copiaCreada = false;

        fondoPadre = GameObject.Find("FondoPrincipal");
    }

    private void Update()
    {
        // Mover el fondo hacia abajo
        transform.Translate(Vector3.down * velocidad * Time.deltaTime);

        // Verificar si se debe crear una copia
        if (!copiaCreada && tiempoCopia <= 0f)
        {
            CrearCopia();
            copiaCreada = true;
        }

        // Actualizar el tiempo para crear una copia
        if (!copiaCreada)
        {
            tiempoCopia -= Time.deltaTime;
        }

        // Verificar si el fondo ha salido completamente de la pantalla
        if (transform.position.y + backgroundHeight < 0f)
        {
            // Eliminar el objeto del fondo
            Destroy(gameObject);
        }
    }

    private void CrearCopia()
    {
        // Crear una copia del fondo en la misma posición de origen
        GameObject nuevaCopia = Instantiate(gameObject, spawnPosition, transform.rotation);
        nuevaCopia.transform.SetParent(fondoPadre.transform);
        nuevaCopia.name = "Fondo";
        
    }
}

