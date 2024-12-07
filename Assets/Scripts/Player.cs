using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : GameEntity
{
    [SerializeField] private float horizontalMovementBoundary = 8f;
    private int health = 1;

    public bool IsDead { get; private set; }

    private ScoreManager scoreManager; // �����ù����ѧ ScoreManager

    public override void Initialize()
    {
        health = 1;
        movementSpeed = 10f;
        IsDead = false;
        scoreManager = FindObjectOfType<ScoreManager>(); // ���� ScoreManager
        if (scoreManager != null)
        {
            scoreManager.StartScoring(); // ������鹡�äӹǳ��ṹ
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
                scoreManager.StopScoring(); // ��ش��äӹǳ��ṹ����ͼ����蹵��
            }
        }
        return IsDead;
    }

    // ������õ�Ǩ�Ѻ��ê��Ѻ Rock
    private void OnTriggerEnter2D(Collider2D other)
    {
        // ��Ǩ�Ѻ��ê��Ѻ Rock
        if (other.CompareTag("Rock"))
        {
            // Ŵ health �����ⴹ Rock
            TakeDamage();
            // ����� Rock ��誹
            Destroy(other.gameObject);
        }
    }
}



