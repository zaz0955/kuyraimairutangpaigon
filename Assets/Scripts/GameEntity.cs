using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameEntity : MonoBehaviour
{
    [SerializeField] protected float movementSpeed = 5f;

    // Abstract method for initialization
    public abstract void Initialize();
}
