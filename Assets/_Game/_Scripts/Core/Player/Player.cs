using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement)), RequireComponent(typeof(PlayerVisual))]
public class Player : MonoBehaviour
{
    private PlayerVisual playerVisual;
    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerVisual = GetComponent<PlayerVisual>();
        playerMovement = GetComponent<PlayerMovement>();
    }
    public void ChangePlayerColor(Color color)
    {
        playerVisual.ChangeColor(color);
    }

}
