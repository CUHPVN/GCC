using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : BaseEnemy
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform[] targets;
    [SerializeField] private int currentTarget = 0;
    private void Awake()
    {
        if(rb == null) rb = GetComponent<Rigidbody2D>();
        OnInit();
    }
    public override void OnInit()
    {
        MaxHealth = 10;
        Health = MaxHealth;
        MovementSpeed = 1;
        currentTarget = 0;
    }
    public override void Move()
    {
        if(targets == null || rb == null) return;
        float range = Vector3.Distance(transform.position, targets[currentTarget].position);
        if (range>0.2f) 
        {
            rb.velocity = (targets[currentTarget].position-transform.position).normalized * MovementSpeed;
        }
        else
        {
            currentTarget++;
            currentTarget%= targets.Length;
            rb.velocity = Vector3.zero;
        }
    }
    public void Update()
    {
        Move();
    }

}
