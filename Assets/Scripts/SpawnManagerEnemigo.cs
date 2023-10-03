using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerEnemigo : MonoBehaviour
{
    public GameObject enemigoPrefab;
    public GameObject enemigoPadre;

    private float cantidadEnemigoMax;
    private float cantidadEnemigoMin;
    private int cantidaCasosMax;
    private int cantidaCasosMin;

    private float tiempoEsperaMax;
    private float tiempoEsperaMin;

    public int numeroCaso;

    // Start is called before the first frame update
    void Start()
    {
        enemigoPadre = GameObject.Find("Spawnner");

        cantidadEnemigoMax = 4;
        cantidadEnemigoMin = 0;

        cantidaCasosMax = 6;
        cantidaCasosMin = -1;

        tiempoEsperaMax = 10;
        tiempoEsperaMin = 6;

        StartCoroutine(SpawnEnemigo());
    }

    IEnumerator SpawnEnemigo()
    {
        while(true)
        {
            float tiempoEspera = Random.Range(tiempoEsperaMax, tiempoEsperaMin);
            float spawnEnemigoTotal = Random.Range(cantidadEnemigoMax, cantidadEnemigoMin);

            yield return new WaitForSeconds(tiempoEspera);

            for(int i = 0; i < spawnEnemigoTotal; i++)
            {
                numeroCaso = Random.Range(cantidaCasosMax, cantidaCasosMin);
                CasosSpawn(numeroCaso);
                yield return new WaitForSeconds(1);
            }
        }
    }

    public void CasosSpawn(int numeroCaso)
    {
        GameObject enemigo = Instantiate(enemigoPrefab, new Vector3(100, 100, 0) , transform.rotation);
        enemigo.GetComponent<Enemigo>().numeroCaso = numeroCaso;
        enemigo.transform.SetParent(enemigoPadre.transform);
        enemigo.name = "Enemigo";
    }
}