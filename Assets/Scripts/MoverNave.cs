using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverNave : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad jugador

    void Update()
    {
        //Control jugador
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Mover nave
        Vector3 movimiento = new Vector3(movimientoHorizontal, movimientoVertical, 0f);
        transform.position += movimiento * velocidad * Time.deltaTime;
    }
}
