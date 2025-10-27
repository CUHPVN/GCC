using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour , ITriggerable
{
    public void OnTrigger()
    {
        Debug.Log("MONSTERRRRRR");
    }
}
