using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : GridGeneric<ItemData>
{
    public static GridManager Instance;

    [SerializeField] private CameraControler cameraControler;
    //
    private void Awake()
    {
        Instance = this;
    }
    private void Reset()
    {
        _camera = Camera.main;
        cameraControler = _camera.GetComponent<CameraControler>();
        //UpdateCamera();
    }
    protected override void OnStart()
    {
        _camera = Camera.main;
        cameraControler= _camera.GetComponent<CameraControler>();
        //UpdateCamera();
    }
    public bool CheckMouseDown()
    {
        mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        mousePos = ToGridPos(mousePos);
        if (!IsClickOnGrid(mousePos)) return false;
        if (GetGridIndexByMouse(mousePos)==-Vector2Int.one) return false;
        return true;
    }
    public bool CheckMouseUp(out Vector2Int index)
    {
        index = -Vector2Int.one;
        mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        mousePos = ToGridPos(mousePos);
        if (!IsClickOnGrid(mousePos)) return false;
        index = GetGridIndexByMouse(mousePos);
        if (index == -Vector2Int.one) return false;
        return true;
    }
    
    private void OnValidate()
    {
        //UpdateCamera();
    }
    
    private void UpdateCamera()
    {
        if(cameraControler==null) return;
        cameraControler.UpdateCameraByGrid(gridPos, cellSize,gridCenter,gridSize);
        lastPos = gridPos;
    }
    protected override void DrawGiz()
    {
        //if(CheckMove()) UpdateCamera();
    }
}
