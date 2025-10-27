using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Player player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) return;
        if (collision.CompareTag("Triggerable"))
        {
            ITriggerable interactable;
            collision.TryGetComponent<ITriggerable>(out interactable);
            if (interactable != null)
            {
                interactable.OnTrigger();
            }
        }
        if (collision.CompareTag("Collectable"))
        {
            ICollectable collectable;
            collision.TryGetComponent<ICollectable>(out collectable);
            if (collectable != null)
            {
                collectable.OnCollected(player);
            }
        }
    }
}
