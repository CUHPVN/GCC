using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) return;
        if (collision.CompareTag("NPC"))
        {
            ITriggerable interactable;
            collision.TryGetComponent<ITriggerable>(out interactable);
            if (interactable != null)
            {
                interactable.OnTrigger();
            }
        }
    }
}
