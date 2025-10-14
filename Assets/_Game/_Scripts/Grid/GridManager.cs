using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private CameraControler cameraControler;

    [SerializeField] private Vector2Int gridSize=Vector2Int.one;
    [SerializeField][Min(0.01f)] private Vector2 cellSize=Vector2.one;

    //Code Ban Dung Danh Em
    private Vector2 gridPos => transform.position;
    private Vector2 mousePos;
    private Vector2 lastPos = Vector2.zero;
    private float x => (float)gridSize.x / 2;
    private float y => (float)gridSize.y / 2;
    private Vector2 gridCenter => new Vector2(x,y);

    private void Reset()
    {
        _camera = Camera.main;
        cameraControler = _camera.GetComponent<CameraControler>();
        UpdateCamera();
    }
    void Start()
    {
        _camera = Camera.main;
        cameraControler= _camera.GetComponent<CameraControler>();
        UpdateCamera();
    }
    private void OnValidate()
    {
        UpdateCamera();
    }
    private void UpdateCamera()
    {
        if(cameraControler==null) return;
        cameraControler.UpdateCameraByGrid(gridPos, cellSize,gridCenter,gridSize);
        lastPos = gridPos;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            WorldToGrid(mousePos);
        }
    }
    private void WorldToGrid(Vector2 pos)
    {
        pos -= gridPos;
        pos /= cellSize;
        if (pos.x > 0 && pos.x <= gridSize.x && pos.y > 0 && pos.y <= gridSize.y)
        {
            Debug.Log(Vector2Int.CeilToInt(pos));
        }
    }
    private void OnDrawGizmos()
    {
        // MoveCamera When Grid Move
        if (Vector2.Distance(lastPos, gridPos) >= 0.01f)
        {
            UpdateCamera();
        }
        Gizmos.color = Color.yellow;
        for(int i = 0; i < gridSize.x; i++)
        {
            for (int j = 0; j < gridSize.y; j++)
            {
                Vector2 pos = gridPos + new Vector2(i+0.5f,j+0.5f) * cellSize;
                Gizmos.DrawWireCube(pos, cellSize);
            }
        }
    }
}
