using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private float score = 0f;
    private bool isHighScore = false;  // ����÷����������ʴ� High Score ���������ѧ
    private bool isScoreStopped = false; // ������������ش���������ṹ���������ѧ

    private float targetY = -4.59f;  // ��ҷ����ҵ�ͧ������ Y �ç

    void Update()
    {
        // ������ṹ���� 1 �ء� �Թҷ� ��Ҥ�ṹ�ѧ�����ش
        if (!isScoreStopped)
        {
            score += Time.deltaTime;
        }

        // �ʴ���ṹ� Console �ء� �Թҷ�
        Debug.Log("Current Score: " + Mathf.FloorToInt(score));

        // ����ҵ��˹� Y �ͧ�����蹹��¡��� ������ҡѺ targetY
        if (transform.position.y <= targetY)
        {
            // �ʴ� High Score ����ͼ���������㹵��˹觷���˹�
            if (!isHighScore)
            {
                Debug.Log("You high score this round is: " + Mathf.FloorToInt(score));
                isHighScore = true;  // ��駤������ʴ� High Score ��������
                isScoreStopped = true; // ��ش���������ṹ
            }
        }
        else
        {
            // ���絡���ʴ� High Score ����ͼ��������������㹵��˹觷���˹�
            isHighScore = false;
        }
    }
}





