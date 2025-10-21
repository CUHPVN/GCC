using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IPickable
{
    [SerializeField] private ItemData _data = new ItemData(0,"ten");
    private Vector2Int currentSlot = -Vector2Int.one;
    private Vector2 lastPos;
    public bool picked=false;
    void Awake()
    {
        lastPos = transform.position;
    }
    public void IsPicked()
    {
        picked = true;
        lastPos = transform.position;
    }

    public void OnPicked()
    {
        //transform.position = InputManager.Instance.MousePos; // PC
        transform.position = lastPos+ InputManager.Instance.DragVector; //Mobile
    }

    public void UnPicked()
    {
        picked = false;
        GridManager.Instance.OnItemUpPicked(_data,ref lastPos,transform,ref currentSlot);
    }

    void Update()
    {
        CheckPicked();
    }
    private void CheckPicked()
    {
        if (!picked) return;
        OnPicked();
    }
}
