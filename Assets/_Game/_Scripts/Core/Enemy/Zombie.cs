using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : BaseEnemy
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform target;
    private void Awake()
    {
        if(rb == null) rb = GetComponent<Rigidbody2D>();
        OnInit();
    }
    public override void OnInit()
    {
        MaxHealth = 10;
        Health = MaxHealth;
        MovementSpeed = 3;
    }
    public override void Move()
    {
        if(target == null || rb == null) return;
        float range = Vector3.Distance(transform.position, target.position);
        if (range>1f && range<4f) 
        {
            rb.velocity = (target.position-transform.position).normalized * MovementSpeed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
    public void Update()
    {
        Move();
    }

}
