using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class GridGeneric<T> : MonoBehaviour where T : class
{
    [SerializeField] protected Camera _camera;
    [SerializeField] protected Vector2Int gridSize = Vector2Int.one;
    [SerializeField][Min(0.01f)] protected Vector2 cellSize = Vector2.one;
    //
    protected Vector2 gridPos => transform.position;
    protected Vector2 mousePos;
    protected Vector2 lastPos = Vector2.zero;
    protected float x => (float)gridSize.x / 2;
    protected float y => (float)gridSize.y / 2;
    public Vector2 gridCenter => new Vector2(x, y)*cellSize;

    private T[,] grid;
    private void Awake()
    {
        _camera = Camera.main;
    }
    private void Start()
    {
        grid = new T[gridSize.x,gridSize.y];
        OnStart();
    }
    protected virtual void OnStart() { }
    void Update()
    {
    }

    protected bool IsClickOnGrid(Vector2 pos)
    {
        if (pos.x >= 0 && pos.x < gridSize.x && pos.y >= 0 && pos.y < gridSize.y) return true;
        return false;
    }
    protected Vector2 ToGridPos(Vector2 pos)
    {
        pos -= gridPos;
        pos /= cellSize;
        pos = Vector2Int.CeilToInt(pos) - Vector2Int.one;
        return pos;
    }
    public Vector2Int GetGridIndexByPos(Vector2 pos)
    {
        pos -= gridPos;
        pos /= cellSize;
        return Vector2Int.CeilToInt(pos) - Vector2Int.one;
    }
    public Vector2Int GetGridIndexByMouse(Vector2 pos)
    {
        if (IsClickOnGrid(pos))
        {
            Vector2Int index = Vector2Int.CeilToInt(pos);
            return index;
        }
        return -Vector2Int.one;
    }
    public T GetGridByIndex(int x,int y)
    {
        if (x >= 0 && x < gridSize.x && y >= 0 && y < gridSize.y)
        return grid[x,y];
        return null;
    }
    public bool IsEmptySlot(int x, int y)
    {
        if (grid[x, y] == null) return true;
        return false;
    }
    public void SetGridByIndex(int x,int y,T t)
    {
        if (x >= 0 && x < gridSize.x && y >= 0 && y < gridSize.y)
        {
            grid[x, y]=t;
        }
    }
    public void TakeDataByIndex(int x, int y)
    {
        if (x >= 0 && x < gridSize.x && y >= 0 && y < gridSize.y)
        {
            grid[x, y] = null;
        }
    }
    public Vector2 GetGridPos(int x,int y)
    {
        return gridPos+ new Vector2Int(x,y)*cellSize + Vector2.one/2f;
    }
    protected virtual bool CheckMove()
    {
        return (Vector2.Distance(lastPos, gridPos) >= 0.01f);
    }
    private void DrawGrid()
    {
        Gizmos.color = Color.green;
        for (int i = 0; i < gridSize.x; i++)
        {
            for (int j = 0; j < gridSize.y; j++)
            {
                Vector2 pos = gridPos + new Vector2(i + 0.5f, j + 0.5f) * cellSize;
                if (grid != null) { if (grid[i, j] != null) Gizmos.color = Color.red; 
                    else Gizmos.color = Color.green; }
                Gizmos.DrawWireCube(pos, cellSize*0.90f);
            }
        }
    }
    protected virtual void DrawGiz() { }
    private void OnDrawGizmos()
    {
        DrawGrid();
        DrawGiz();
    }
}
