using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    private CameraAdjust cameraAdjust = new CameraAdjust();
    public void UpdateCameraByGrid(Vector2 gridPos,Vector2 cellSize,Vector2 gridCenter,Vector2 gridSize)
    {
       
        Camera.main.transform.position = cameraAdjust.CalPos(gridPos,cellSize,gridCenter);
        Camera.main.orthographicSize = cameraAdjust.CalOrthoSize(cellSize * gridSize);
    }
}
