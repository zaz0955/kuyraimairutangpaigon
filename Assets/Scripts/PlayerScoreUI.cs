using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText; // �����ù����ѧ TextMeshProUGUI �����ʴ���ṹ
    private ScoreManager scoreManager; // �����ù����ѧ ScoreManager

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
            // �ѻവ��ͤ����ʴ��Ť�ṹ
            scoreText.text = "Score: " + Mathf.FloorToInt(scoreManager.Score).ToString();
        }
    }
}


