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
        // รับ Input จากผู้เล่น
        moveInput = Input.GetAxis("Horizontal");

        // กระโดดถ้ากดปุ่ม Jump และอยู่บนพื้น
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // ตรวจสอบว่าตัวละครอยู่บนพื้นหรือไม่
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void FixedUpdate()
    {
        // เคลื่อนที่ซ้าย-ขวา
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // เปลี่ยนทิศทาง Sprite โดยไม่เปลี่ยนขนาด
        if (moveInput > 0)
        {
            spriteRenderer.flipX = false; // หันไปทางขวา
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true; // หันไปทางซ้าย
        }
    }

    void OnDrawGizmos()
    {
        // แสดงเส้นรอบวงของ Ground Check ใน Scene View
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
