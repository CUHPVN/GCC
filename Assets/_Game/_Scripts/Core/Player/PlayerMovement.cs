using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour, IUpdateable , IStopUpdate
{
    private InputAction moveAction;
    private Rigidbody2D rb;
    [SerializeField] private float movementSpeed=5f;
    private void OnEnable()
    {
        UpdateManager.Register(this);
        UpdateManager.RegisterStopUpdate(this);

    }
    private void OnDisable()
    {
        UpdateManager.UnRegister(this);
        UpdateManager.UnRegisterStopUpdate(this);

    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Move");
    }

    public void OnUpdate()
    {
        rb.velocity = moveAction.ReadValue<Vector2>() * movementSpeed;
    }
    public void OnStopUpdate()
    {
        rb.velocity = Vector3.zero;
    }
}
