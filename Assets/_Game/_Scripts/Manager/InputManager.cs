using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    [SerializeField] private Camera _camera;
    private Vector2 startPos;
    private Vector2 currentPos;
    public Vector3 MousePos; //
    public Vector2 DragVector=>currentPos-startPos; //
    private void Awake()
    {
        _camera = Camera.main;
    }
    private void Update()
    {
        UpdateMousePosOnClick();
    }
    private void UpdateMousePosOnClick()
    {
        if(Input.GetMouseButtonDown(0)) startPos = _camera.ScreenToWorldPoint(Input.mousePosition);
        MousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        MousePos.z = 0;
        currentPos = MousePos;
    }
}
