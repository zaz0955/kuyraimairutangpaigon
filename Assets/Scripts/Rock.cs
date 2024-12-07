using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Rock : GameEntity
{
    // ตัวแปรสำหรับ ScoreManager
    private ScoreManager scoreManager;

    private void Awake()
    {
        // ค้นหา ScoreManager ในฉาก
        scoreManager = FindObjectOfType<ScoreManager>();

        // ตรวจสอบว่าเจอ ScoreManager หรือไม่
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found!");
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public enum RockType
    {
        Small,
        Medium,
        Large
    }

    [SerializeField] private RockType rockType = RockType.Medium;
    private SpriteRenderer spriteRenderer;

    // Initialize rock with type-specific properties
    public override void Initialize()
    {
        if (rockType == RockType.Medium)
        {
            rockType = (RockType)Random.Range(0, 3);
        }

        // Configure speed and visual representation based on rock type
        switch (rockType)
        {
            case RockType.Small:
                movementSpeed = 7f;
                if (spriteRenderer) spriteRenderer.color = Color.green;
                break;
            case RockType.Medium:
                movementSpeed = 5f;
                if (spriteRenderer) spriteRenderer.color = Color.yellow;
                break;
            case RockType.Large:
                movementSpeed = 3f;
                if (spriteRenderer) spriteRenderer.color = Color.red;
                break;
        }
    }

    private void Update()
    {
        // Move rock downward
        transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);
    }

    // Optional: Destroy rock when it goes off screen
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // Detect collision with Player (Trigger)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // เมื่อ Player โดน Rock ให้ลด health ของ Player
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage();  // เรียกฟังก์ชัน TakeDamage ใน Player class เพื่อลด health
                scoreManager.StopScoring(); // หยุดการคำนวณคะแนน
            }

            // ทำลาย Rock เมื่อชนกับ Player
            Destroy(gameObject);
        }
    }

}

