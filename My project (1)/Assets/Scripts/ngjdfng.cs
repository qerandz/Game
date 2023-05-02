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
    [SerializeField] private float maxSpawnTime = 4f; // ����������� ������������ ����� �������� �� 2 �������

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            // �������� ��������� ������
            GameObject prefabToSpawn = Random.value < 0.5f ? lowPrefab : highPrefab;

            // ���� 2 ������� ����� ������� ������ �������
            yield return new WaitForSeconds(1f);
            Instantiate(bonus, spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
            // ������� ������
            Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);

            // ���� ��������� ����� ����� ��������� �������
            float randomTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(randomTime);
        }
    }
}
