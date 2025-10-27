using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    public float MaxHealth { get; protected set; }
    public float Health { get; protected set; }

    public float MovementSpeed { get; protected set; }

    public abstract void OnInit();
    public abstract void Move();
}
