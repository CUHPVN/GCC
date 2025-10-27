using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseItem : MonoBehaviour ,ICollectable
{
    public virtual void OnCollected(Player player)
    {
        Debug.Log($"Collected: {name}");
        gameObject.SetActive(false);
    }
}
