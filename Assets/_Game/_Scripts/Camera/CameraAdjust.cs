using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdjust
{
    public float Cal(Vector2 vector2)
    {
        Bounds bounds = new Bounds();
        bounds.Encapsulate(Vector2.zero);
        bounds.Encapsulate(vector2);
        bounds.Expand(1);
        float x = 9f/16 * bounds.size.x/2; 
        float y = bounds.size.y/2;
        return Mathf.Max(x,y);
    }
}
