using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject rockPrefab; // Prefab �ͧ�Թ
    public float spawnInterval = 2f; // �������������ҧ��� Spawn

    [Header("Spawn Area")]
    public Vector3 spawnStart = new Vector3(-4.13f, 2.89f, 0f); // �ش������鹢ͧ��鹷�� Spawn
    public Vector3 spawnEnd = new Vector3(2.64f, 2.89f, 0f); // �ش����ش�ͧ��鹷�� Spawn

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnRock();
            timer = 0f; // ���絵�ǨѺ����
        }
    }

    void SpawnRock()
    {
        // �������˹����᡹ X (�����鹷�����˹�)
        float randomX = Random.Range(spawnStart.x, spawnEnd.x);
        float yPosition = spawnStart.y; // ᡹ Y �����
        float zPosition = spawnStart.z; // ᡹ Z �����

        Vector3 spawnPosition = new Vector3(randomX, yPosition, zPosition);

        // ���ҧ�Թ�ҡ Prefab
        Instantiate(rockPrefab, spawnPosition, Quaternion.identity);
    }

    void OnDrawGizmos()
    {
        // �Ҵ����ʴ���鹷�� Spawn � Scene View
        Gizmos.color = Color.red;
        Gizmos.DrawLine(spawnStart, spawnEnd);
    }
}
