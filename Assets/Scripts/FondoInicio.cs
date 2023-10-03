using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoInicio : MonoBehaviour
{
    public float velocidad; // Velocidad de movimiento del fondo

    private Renderer backgroundRenderer;
    private float backgroundHeight;

    private void Start()
    {
        // Obtener el componente Renderer y calcular la altura del fondo
        backgroundRenderer = GetComponent<Renderer>();
        backgroundHeight = backgroundRenderer.bounds.size.y;
    }

    private void Update()
    {
        // Mover el fondo hacia abajo
        transform.Translate(Vector3.down * velocidad * Time.deltaTime);

        // Verificar si el fondo ha salido completamente de la pantalla
        if (transform.position.y + backgroundHeight < 0f)
        {
            // Eliminar el objeto del fondo
            Destroy(gameObject);
        }
    }
}
