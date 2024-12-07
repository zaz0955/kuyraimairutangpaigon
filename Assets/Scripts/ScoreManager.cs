using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ScoreManager : MonoBehaviour
{
    private float score = 0f;
    private bool isScoreStopped = false;
    private bool isHighScore = false;

    public float Score => score; // Getter สำหรับคะแนน

    void Update()
    {
        // อัปเดตคะแนนในแต่ละเฟรม
        if (!isScoreStopped)
        {
            score += Time.deltaTime; // เพิ่มคะแนนทุกๆ วินาที
        }
    }

    // ฟังก์ชันเริ่มต้นการคำนวณคะแนน
    public void StartScoring()
    {
        score = 0f; // เริ่มต้นคะแนน
        isScoreStopped = false;
    }

    // ฟังก์ชันหยุดการคำนวณคะแนน
    public void StopScoring()
    {
        isScoreStopped = true;
    }

    // ฟังก์ชันสำหรับเช็คว่าเป็น HighScore หรือไม่
    public void CheckHighScore()
    {
        if (!isHighScore)
        {
            Debug.Log("Your high score this round is: " + Mathf.FloorToInt(score));
            isHighScore = true;
        }
    }

    // ฟังก์ชันรีเซ็ต HighScore เมื่อไม่อยู่ในตำแหน่งที่กำหนด
    public void ResetHighScore()
    {
        isHighScore = false;
    }
}


