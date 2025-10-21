using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegatesStudy : MonoBehaviour
{
    public Action<int> OnPlayerMovement;
    public Func<int> func;

    void Start()
    {
        OnPlayerMovement += Move;
        func = HPLeft;
    }

    void Update()
    {
        
    }
    private void Move(int i)
    {

    }
    private int HPLeft()
    {
        return 0;
    }
}
