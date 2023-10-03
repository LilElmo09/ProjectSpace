using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFondo : MonoBehaviour
{
    public Color[] colores;
    public float duration = 100.0F;
    private int currentIndex = 0;
    private float elapsedTime = 0f;

    public Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
        CambiaColor();
    }

    void FixedUpdate()
    {
        elapsedTime += Time.deltaTime;
        CambiaColor();
    }

    void CambiaColor()
    {
        if (elapsedTime >= duration)
        {
            // Cambiar al siguiente color
            currentIndex = (currentIndex + 1) % colores.Length;
            elapsedTime = 0f;
        }

        float t = elapsedTime / duration;
        cam.backgroundColor = Color.Lerp(colores[currentIndex], colores[(currentIndex + 1) % colores.Length], t);
    }
}
