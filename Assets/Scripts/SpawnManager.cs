using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaculoPrefab; // Prefab del obstáculo
    public GameObject padreObstaculo; // Padre del obstáculo
    public Vector3[] spawnPositions; // Arreglo de las coordenadas de spawn
    private float minSpawnDelay = 0.3f; // Retardo mínimo entre spawns
    private float maxSpawnDelay = 3f; // Retardo máximo entre spawns
    private int minSpawnCount = 0; // Cantidad mínima de obstáculos por spawn
    private int maxSpawnCount = 3; // Cantidad máxima de obstáculos por spawn


    private List<Vector3> usedSpawnPositions = new List<Vector3>(); // Lista de posiciones de spawn utilizadas en el ciclo actual

    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            float spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
            int spawnCount = Random.Range(minSpawnCount, maxSpawnCount + 1);

            yield return new WaitForSeconds(spawnDelay);

            usedSpawnPositions.Clear(); // Limpiar la lista de posiciones de spawn utilizadas en el ciclo actual

            for (int i = 0; i < spawnCount; i++)
            {
                Vector3 spawnPosition = GetRandomSpawnPosition();
                GameObject hijoObstaculo = Instantiate(obstaculoPrefab, spawnPosition, Quaternion.identity);
                hijoObstaculo.transform.SetParent(padreObstaculo.transform); // Agregar el objeto a un padre
                usedSpawnPositions.Add(spawnPosition); // Agregar la posición de spawn utilizada a la lista
            }
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 spawnPosition = spawnPositions[Random.Range(0, spawnPositions.Length)];

        // Verificar si la posición de spawn ya ha sido utilizada en el ciclo actual
        while (usedSpawnPositions.Contains(spawnPosition))
        {
            spawnPosition = spawnPositions[Random.Range(0, spawnPositions.Length)];
        }

        return spawnPosition;
    }
}