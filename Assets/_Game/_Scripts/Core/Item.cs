using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IPickable
{
    [SerializeField] private ItemData _data = new ItemData(0,"ten");
    private Vector2Int currentSlot = -Vector2Int.one;
    private Vector2 lastPos;
    public bool picked=false;
    void Start()
    {
        lastPos = transform.position;
    }
    public void IsPicked()
    {
        picked = true;
    }

    public void OnPicked()
    {
        //transform.position = InputManager.Instance.MousePos; // PC
        transform.position = lastPos+ InputManager.Instance.DragVector; //Mobile
    }

    public void UnPicked()
    {
        picked = false;
        Vector2Int index;
        if (GridManager.Instance.CheckMouseUp(out index))
        {
            if(GridManager.Instance.IsEmptySlot(index.x, index.y))
            {
                GridManager.Instance.SetGridByIndex(index.x,index.y,_data);
                transform.position = GridManager.Instance.GetGridPos(index.x,index.y);
                lastPos = transform.position;
                if (currentSlot != -Vector2Int.one) GridManager.Instance.TakeDataByIndex(currentSlot.x,currentSlot.y);
                currentSlot = index;
                transform.position = lastPos;
            }
            else
            {
                transform.position = lastPos;
            }
        }
        else
        {
            if (currentSlot != -Vector2Int.one) GridManager.Instance.TakeDataByIndex(currentSlot.x, currentSlot.y);
            currentSlot = -Vector2Int.one;
            lastPos = transform.position;
        }
        //transform.position = lastPos;
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
