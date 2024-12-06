using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private float score = 0f;
    private bool isHighScore = false;  // ตัวแปรที่ใช้เช็คว่าแสดง High Score แล้วหรือยัง
    private bool isScoreStopped = false; // ตัวแปรเช็คว่าหยุดการเพิ่มคะแนนแล้วหรือยัง

    private float targetY = -4.59f;  // ค่าที่เราต้องการให้ Y ตรง

    void Update()
    {
        // เพิ่มคะแนนทีละ 1 ทุกๆ วินาที ถ้าคะแนนยังไม่หยุด
        if (!isScoreStopped)
        {
            score += Time.deltaTime;
        }

        // แสดงคะแนนใน Console ทุกๆ วินาที
        Debug.Log("Current Score: " + Mathf.FloorToInt(score));

        // เช็คว่าตำแหน่ง Y ของผู้เล่นน้อยกว่า หรือเท่ากับ targetY
        if (transform.position.y <= targetY)
        {
            // แสดง High Score เมื่อผู้เล่นอยู่ในตำแหน่งที่กำหนด
            if (!isHighScore)
            {
                Debug.Log("You high score this round is: " + Mathf.FloorToInt(score));
                isHighScore = true;  // ตั้งค่าให้แสดง High Score ครั้งเดียว
                isScoreStopped = true; // หยุดการเพิ่มคะแนน
            }
        }
        else
        {
            // รีเซ็ตการแสดง High Score เมื่อผู้เล่นไม่ได้อยู่ในตำแหน่งที่กำหนด
            isHighScore = false;
        }
    }
}





