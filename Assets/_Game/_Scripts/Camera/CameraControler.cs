using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private CameraAdjust cameraAdjust = new CameraAdjust();
    public void UpdateCameraByGrid(Vector2 gridPos,Vector2 cellSize,Vector2 gridCenter,Vector2 gridSize)
    {
        if (_camera == null) _camera = GetComponent<Camera>();
        _camera.transform.position = cameraAdjust.CalPos(gridPos,cellSize,gridCenter);
        _camera.orthographicSize = cameraAdjust.CalOrthoSize(cellSize * gridSize);
    }
}
