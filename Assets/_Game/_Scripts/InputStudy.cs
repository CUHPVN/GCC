using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputStudy : MonoBehaviour
{
    void GetKeyFamily()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            DebugMessage("An Space", this.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DebugMessage("Giu Space", this.gameObject);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            DebugMessage("Tha Space", this.gameObject);
        }
    }
    void Update()
    {
        GetKeyFamily();
    }
    private void DebugMessage(string message,GameObject obj)
    {
        Debug.Log(message+" - From: "+obj);
    }
}
