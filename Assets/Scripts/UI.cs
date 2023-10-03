using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject interfazPartida;
    public GameObject interfazFinal;
    public GameObject interfazInicio;
    public GameObject interfazPause;
    public Text textoPuntuacionFinal;
    public Text textoPuntuacionPause;
    public int puntuacion;
    private bool pause;
    public bool estadoVida;
    public bool comenzo;
    void Start()
    {
        Time.timeScale = 0;
        interfazInicio.SetActive(true);
        interfazFinal.SetActive(false);
        interfazPartida.SetActive(false);
        pause = false;
        estadoVida = true;
        comenzo = true;
    }
    void Update()
    {
        if(comenzo && Input.GetKey(KeyCode.Space))
        {
            Time.timeScale = 1;
            comenzo = false;
            interfazPartida.SetActive(true);
            interfazInicio.SetActive(false);
            interfazPause.SetActive(false);
        }else
        {
            if (estadoVida)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    pause = !pause;
                    if (pause)
                    {
                        textoPuntuacionPause.text = "Score \n" + puntuacion;
                        Time.timeScale = 0;
                        interfazPartida.SetActive(false);
                        interfazPause.SetActive(true);
                    }
                    else
                    {
                        Time.timeScale = 1;
                        interfazPartida.SetActive(true);
                        interfazPause.SetActive(false);
                    }
                }
            }
            else
            {   
                textoPuntuacionFinal.text = "Score \n" + puntuacion;
                Time.timeScale = 0;  
                interfazPartida.SetActive(false);
                interfazFinal.SetActive(true);
            }
        }

    }
    public void ReiniciarPartida()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void VolverAlMenuPrincipal()
    {
        SceneManager.LoadScene("Menu Principal");
    }
}

