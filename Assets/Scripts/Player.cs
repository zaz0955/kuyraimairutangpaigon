using UnityEngine;

public class Player2D : GameEntity
{
    [SerializeField] private float horizontalMovementBoundary = 8f;

    // Player health
    private int health = 1;

    // Initialize player
    public override void Initialize()
    {
        health = 1;
        movementSpeed = 10f;
    }

    private void Update()
    {
        // Get horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate movement
        Vector2 movement = new Vector2(horizontalInput * movementSpeed * Time.deltaTime, 0);

        // Apply movement with boundary clamping
        Vector2 newPosition = (Vector2)transform.position + movement;
        newPosition.x = Mathf.Clamp(newPosition.x, -horizontalMovementBoundary, horizontalMovementBoundary);

        transform.position = newPosition;
    }

    // Damage handling
    public bool TakeDamage()
    {
        health--;
        return health <= 0;
    }
}
