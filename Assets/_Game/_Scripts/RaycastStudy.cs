using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastStudy : MonoBehaviour
{
    void Raycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right,Mathf.Infinity);
        RaycastHit2D[] hit2D = Physics2D.RaycastAll(transform.position,Vector2.down,Mathf.Infinity); 
    }
}
