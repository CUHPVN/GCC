using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour, IUpdateable
{
    private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Vector3 left = new Vector3(-1,1,1);
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        UpdateManager.Register(this);
    }
    private void OnDisable()
    {
        UpdateManager.UnRegister(this);
    }
    public void ChangeColor(Color color)
    {
        spriteRenderer.color = color;
    }
    public void OnUpdate()
    {
        if(rb.velocity.x > 0.1f)
        {
            transform.localScale = Vector3.one;
        } else if(rb.velocity.x < -0.1f)
        {
            transform.localScale = left;
        }
    }
}
