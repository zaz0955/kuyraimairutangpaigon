using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Rock2D : GameEntity
{
    // Enum for rock types with different characteristics
    public enum RockType
    {
        Small,
        Medium,
        Large
    }

    [SerializeField] private RockType rockType = RockType.Medium;

    // Sprite renderer for visual representation
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Initialize rock with type-specific properties
    public override void Initialize()
    {
        // Randomize rock type if not preset
        if (rockType == RockType.Medium)
        {
            rockType = (RockType)Random.Range(0, 3);
        }

        // Configure speed and visual representation based on rock type
        switch (rockType)
        {
            case RockType.Small:
                movementSpeed = 7f;
                if (spriteRenderer) spriteRenderer.color = Color.green;
                break;
            case RockType.Medium:
                movementSpeed = 5f;
                if (spriteRenderer) spriteRenderer.color = Color.yellow;
                break;
            case RockType.Large:
                movementSpeed = 3f;
                if (spriteRenderer) spriteRenderer.color = Color.red;
                break;
        }
    }

    private void Update()
    {
        // Move rock downward
        transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);
    }

    // Optional: Destroy rock when it goes off screen
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
