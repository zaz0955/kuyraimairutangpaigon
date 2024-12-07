using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : GameEntity
{
    [SerializeField] private float horizontalMovementBoundary = 8f;
    private int health = 1;

    public bool IsDead { get; private set; }

    private ScoreManager scoreManager; // รีเฟอเรนซ์ไปยัง ScoreManager

    public override void Initialize()
    {
        health = 1;
        movementSpeed = 10f;
        IsDead = false;
        scoreManager = FindObjectOfType<ScoreManager>(); // ค้นหา ScoreManager
        if (scoreManager != null)
        {
            scoreManager.StartScoring(); // เริ่มต้นการคำนวณคะแนน
        }
    }

    private void Update()
    {
        if (IsDead) return;

        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput * movementSpeed * Time.deltaTime, 0);
        Vector2 newPosition = (Vector2)transform.position + movement;
        newPosition.x = Mathf.Clamp(newPosition.x, -horizontalMovementBoundary, horizontalMovementBoundary);
        transform.position = newPosition;
    }

    public bool TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            IsDead = true;
            if (scoreManager != null)
            {
                scoreManager.StopScoring(); // หยุดการคำนวณคะแนนเมื่อผู้เล่นตาย
            }
        }
        return IsDead;
    }

    // เพิ่มการตรวจจับการชนกับ Rock
    private void OnTriggerEnter2D(Collider2D other)
    {
        // ตรวจจับการชนกับ Rock
        if (other.CompareTag("Rock"))
        {
            // ลด health เมื่อโดน Rock
            TakeDamage();
            // ทำลาย Rock ที่ชน
            Destroy(other.gameObject);
        }
    }
}



