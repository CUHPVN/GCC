using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStudy : MonoBehaviour
{
    [SerializeField] UnityEvent unityEvent;
    int health;
    
    private void CheckDeath()
    {
        if (health <= 0)
        {
            GameEvent.OnPlayerDeath?.Invoke();
            unityEvent?.Invoke();
        }
    }
}
