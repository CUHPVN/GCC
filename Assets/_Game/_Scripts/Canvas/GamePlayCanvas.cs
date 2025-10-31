using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayCanvas : MonoBehaviour
{
    public void Pause()
    {
        if (GameManager.IsState(GameState.Play))
        {
            GameManager.ChangeState(GameState.Pause);
        }else if (GameManager.IsState(GameState.Pause))
        {
            GameManager.ChangeState(GameState.Play);
        }
    }
}
