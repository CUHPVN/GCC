using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    [SerializeField] private Transform cameraHolder;
    [SerializeField] private Transform target;
    [SerializeField] private float damp = 0.1f;
    [SerializeField] private Camera _camera;
    private CameraAdjust cameraAdjust = new CameraAdjust();
    public void UpdateCameraByGrid(Vector2 gridPos,Vector2 cellSize,Vector2 gridCenter,Vector2 gridSize)
    {
        if (_camera == null) _camera = GetComponent<Camera>();
        _camera.transform.position = cameraAdjust.CalPos(gridPos,cellSize,gridCenter);
        _camera.orthographicSize = cameraAdjust.CalOrthoSize(cellSize * gridSize);
    }
    private void LateUpdate()
    {
        MoveToTarget();
    }
    public void MoveToTarget()
    {
        if(target == null) return;
        cameraHolder.transform.position = Vector2.Lerp(cameraHolder.transform.position, target.transform.position, damp*Time.deltaTime);
    }
}
