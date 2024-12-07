using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ScoreManager : MonoBehaviour
{
    private float score = 0f;
    private bool isScoreStopped = false;
    private bool isHighScore = false;

    public float Score => score; // Getter ����Ѻ��ṹ

    void Update()
    {
        // �ѻവ��ṹ��������
        if (!isScoreStopped)
        {
            score += Time.deltaTime; // ������ṹ�ء� �Թҷ�
        }
    }

    // �ѧ��ѹ������鹡�äӹǳ��ṹ
    public void StartScoring()
    {
        score = 0f; // ������鹤�ṹ
        isScoreStopped = false;
    }

    // �ѧ��ѹ��ش��äӹǳ��ṹ
    public void StopScoring()
    {
        isScoreStopped = true;
    }

    // �ѧ��ѹ����Ѻ������� HighScore �������
    public void CheckHighScore()
    {
        if (!isHighScore)
        {
            Debug.Log("Your high score this round is: " + Mathf.FloorToInt(score));
            isHighScore = true;
        }
    }

    // �ѧ��ѹ���� HighScore ������������㹵��˹觷���˹�
    public void ResetHighScore()
    {
        isHighScore = false;
    }
}


