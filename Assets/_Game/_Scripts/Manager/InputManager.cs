using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    [SerializeField] private Camera _camera;
    private Vector2 startPos;
    private Vector2 currentPos;
    public Vector2 MousePos; //
    public Vector2 DragVector=>currentPos-startPos; //
    private void Awake()
    {
        _camera = Camera.main;
    }
    private void OnEnable()
    {
    }
    public void Update()
    {
        UpdateMousePosOnClick();
    }
    private void UpdateMousePosOnClick()
    {
        if(Input.GetMouseButtonDown(0)) startPos = _camera.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetKeyDown(KeyCode.Escape)) Pause();
        MousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        currentPos = MousePos;
    }
    private void Pause() //test
    {
        if (GameManager.IsState(GameState.Play))
        {
            GameManager.ChangeState(GameState.Pause);
        }
        else if (GameManager.IsState(GameState.Pause))
        {
            GameManager.ChangeState(GameState.Play);
        }
    }
    private void OnDisable()
    {
    }
}
