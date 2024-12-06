using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // �Ѻ Input �ҡ������
        moveInput = Input.GetAxis("Horizontal");

        // ���ⴴ��ҡ����� Jump ������躹���
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // ��Ǩ�ͺ��ҵ���Ф����躹����������
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void FixedUpdate()
    {
        // ����͹������-���
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // ����¹��ȷҧ Sprite ���������¹��Ҵ
        if (moveInput > 0)
        {
            spriteRenderer.flipX = false; // �ѹ价ҧ���
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true; // �ѹ价ҧ����
        }
    }

    void OnDrawGizmos()
    {
        // �ʴ�����ͺǧ�ͧ Ground Check � Scene View
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
