using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    private void OnEnable()
    {
        GameEvent.OnPlayerDeath += PlayerDieAudio;
    }
    private void OnDisable()
    {
        GameEvent.OnPlayerDeath -= PlayerDieAudio;
    }
    private void PlayerDieAudio()
    {

    }
}
