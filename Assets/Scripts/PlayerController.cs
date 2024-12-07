using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb2d;
    Vector2 move;
    float moveX;
    private SpriteRenderer spriteRenderer;
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;

    void Start()
    {
        speed = 500f;
        jumpSpeed = 15f;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(moveX * speed * Time.fixedDeltaTime, rb2d.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.velocity = new Vector2(0, jumpSpeed);
        }
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(moveX * speed * Time.fixedDeltaTime, rb2d.velocity.y);
        // พลิกทิศทางตัวละคร
        if (moveX > 0)
        {
            spriteRenderer.flipX = false; // หันไปทางขวา
        }
        else if (moveX < 0)
        {
            spriteRenderer.flipX = true; // หันไปทางซ้าย
        }
    }
}