using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Puntuacion : MonoBehaviour
{
    public bool estadoVida;
    public int puntuacion = 0;
    public int vida = 3;

    public Text textoPuntuacion;
    public Text textoVida;

    public float tiempoEspera = 1;

    private IEnumerator Start()
    {
        estadoVida = true;
        while (true)
        {
            IncrementarPuntuacion();
            AcutializarVida();
            yield return new WaitForSeconds(tiempoEspera);
        }
    }

    void IncrementarPuntuacion()
    {
        puntuacion++;
        ActualizarPuntuacion();
    }

    void ActualizarPuntuacion()
    {
        textoPuntuacion.text = "Score: " + puntuacion;
        this.GetComponent<UI>().puntuacion = puntuacion;
    }

    void AcutializarVida()
    {
        textoVida.text = "Life: " + vida;

        if(vida <= 0)
        {
            estadoVida = false;
            this.GetComponent<UI>().estadoVida = estadoVida;
        }        
    }

    public void OnTriggerEnter2D(Collider2D collisionObstaculo)
    {
        if(collisionObstaculo.gameObject.CompareTag("Obstaculo"))
        {
            Dano();
        }

        if(collisionObstaculo.gameObject.CompareTag("BalaEnemigo"))
        {
            Dano();
        }
        
        void Dano()
        {
            Destroy(collisionObstaculo.gameObject);
            puntuacion = puntuacion - 10;
            ActualizarPuntuacion();
            vida--;
            AcutializarVida();
        }
    }

    public void MatarEnemigo()
    {
        puntuacion = puntuacion + 22;
        ActualizarPuntuacion();
    }
    public void BajaPorDisparar()
    {
        puntuacion = puntuacion - 2;
        ActualizarPuntuacion();
    }
    public void AlDestruirAsteroide()
    {
        puntuacion = puntuacion + 2;
        ActualizarPuntuacion();
    }
}