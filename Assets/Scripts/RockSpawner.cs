using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject rockPrefab; // Prefab ของหิน
    public float spawnInterval = 2f; // ระยะเวลาระหว่างการ Spawn

    [Header("Spawn Area")]
    public Vector3 spawnStart = new Vector3(-4.13f, 2.89f, 0f); // จุดเริ่มต้นของพื้นที่ Spawn
    public Vector3 spawnEnd = new Vector3(2.64f, 2.89f, 0f); // จุดสิ้นสุดของพื้นที่ Spawn

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnRock();
            timer = 0f; // รีเซ็ตตัวจับเวลา
        }
    }

    void SpawnRock()
    {
        // สุ่มตำแหน่งในแนวแกน X (ตามพื้นที่ที่กำหนด)
        float randomX = Random.Range(spawnStart.x, spawnEnd.x);
        float yPosition = spawnStart.y; // แกน Y คงที่
        float zPosition = spawnStart.z; // แกน Z คงที่

        Vector3 spawnPosition = new Vector3(randomX, yPosition, zPosition);

        // สร้างหินจาก Prefab
        Instantiate(rockPrefab, spawnPosition, Quaternion.identity);
    }

    void OnDrawGizmos()
    {
        // วาดเส้นแสดงพื้นที่ Spawn ใน Scene View
        Gizmos.color = Color.red;
        Gizmos.DrawLine(spawnStart, spawnEnd);
    }
}
