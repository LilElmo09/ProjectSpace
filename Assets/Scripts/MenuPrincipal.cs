using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject interfazMenuPrincipal;
    public GameObject interfazComoJugar;
    public GameObject interfazTablaPuntiacion;
    public GameObject interfazPuntaje;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void Jugar()
    {
        SceneManager.LoadScene("Game");
    }
    public void CerrarJuego()
    {
        Application.Quit();
    }

    public void IrInterfazComoJugar()
    {
        interfazMenuPrincipal.SetActive(false);
        interfazComoJugar.SetActive(true);
    }

    public void VolverMeniPrincipal()
    {
        interfazMenuPrincipal.SetActive(true);
        interfazComoJugar.SetActive(false);
        interfazPuntaje.SetActive(false);
    }

    public void IrInterfazPuntuacion()
    {
        interfazMenuPrincipal.SetActive(false);
        interfazPuntaje.SetActive(true);
    }
}
