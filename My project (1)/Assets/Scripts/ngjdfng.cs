using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ngjdfng : MonoBehaviour
{
    [SerializeField] private GameObject lowPrefab;
    [SerializeField] private GameObject highPrefab;
    [SerializeField] private GameObject bonus;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float minSpawnTime = 0f;
    [SerializeField] private float maxSpawnTime = 4f; // увеличиваем максимальное время ожидания на 2 секунды

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            // выбираем случайный префаб
            GameObject prefabToSpawn = Random.value < 0.5f ? lowPrefab : highPrefab;

            // ждем 2 секунды перед спавном нового объекта
            yield return new WaitForSeconds(1f);
            Instantiate(bonus, spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
            // спавним объект
            Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);

            // ждем случайное время перед следующим спавном
            float randomTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(randomTime);
        }
    }
}
