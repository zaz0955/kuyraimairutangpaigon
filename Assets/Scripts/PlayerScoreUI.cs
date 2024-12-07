using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText; // รีเฟอเรนซ์ไปยัง TextMeshProUGUI ที่จะแสดงคะแนน
    private ScoreManager scoreManager; // รีเฟอเรนซ์ไปยัง ScoreManager

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found!");
        }
    }

    void Update()
    {
        if (scoreManager != null)
        {
            // อัปเดตข้อความแสดงผลคะแนน
            scoreText.text = "Score: " + Mathf.FloorToInt(scoreManager.Score).ToString();
        }
    }
}


