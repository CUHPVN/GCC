using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private InputAction moveAction;
    private Rigidbody2D rb;
    [SerializeField] private float movementSpeed=5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        rb.velocity = moveAction.ReadValue<Vector2>() * movementSpeed;
    }
}
