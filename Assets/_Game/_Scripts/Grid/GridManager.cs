using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private CameraAdjust cameraAdjust = new CameraAdjust();

    [SerializeField] private Vector2Int gridSize=Vector2Int.zero;
    [SerializeField][Min(0)] private Vector2 cellSize=Vector2.one;

    //Code Ban Dung Danh Em
    private Vector2 gridPos;
    private Vector2 mousePos;
    private Vector3 offSet = new Vector3(0, 0, -10);
    private float x => (float)gridSize.x / 2;
    private float y => (float)gridSize.y / 2;
    private Vector2 camPos;

    void Start()
    {
        _camera = Camera.main;
        UpdateCamera();
    }
    private void OnValidate()
    {
        UpdateCamera();
    }
    private void UpdateCamera()
    {
        camPos = new Vector2(x, y);
        _camera.transform.position = (Vector3)(camPos * cellSize) + offSet;
        _camera.orthographicSize = cameraAdjust.Cal(cellSize*gridSize);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = _camera.ScreenToWorldPoint(Input.mousePosition)/cellSize;
            if (mousePos.x>0 && mousePos.x <= gridSize.x &&mousePos.x > 0&& mousePos.y <= gridSize.y)
            {
                Debug.Log(Vector2Int.CeilToInt(mousePos));
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for(int i = 0; i < gridSize.x; i++)
        {
            for (int j = 0; j < gridSize.y; j++)
            {
                gridPos = new Vector2(i+0.5f, j+0.5f) * cellSize;
                Gizmos.DrawWireCube(gridPos, cellSize);
            }
        }
    }
}
