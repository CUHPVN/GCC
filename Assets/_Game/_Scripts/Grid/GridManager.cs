using System.Collections;
using System.Collections.Generic;
using UnityEditor.Sprites;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    [SerializeField] protected Vector2Int gridSize = Vector2Int.one;
    [SerializeField][Min(0.01f)] protected Vector2 cellSize = Vector2.one;
    private GridGeneric<ItemData> grid;
    //
    private void Awake()
    {
        Instance = this;
        grid = new GridGeneric<ItemData>(gridSize,cellSize,transform);
    }
    private void Reset()
    {
        //UpdateCamera();
    }
    private void Update()
    {
        grid.HoverUpdate(InputManager.Instance.MousePos);
    }

    public void OnItemUpPicked(ItemData _data, ref Vector2 lastPos,Transform transformPos,ref Vector2Int currentSlot,Item item)
    {
        Vector2Int index;
        if (grid.CheckMouseUp(out index))
        {
            if (grid.IsEmptySlot(index.x, index.y))
            {
                grid.SetGridByIndex(index.x, index.y, _data);
                Vector2 targetPos = grid.GetGridPos(index.x, index.y);
                lastPos = targetPos;
                if (currentSlot != -Vector2Int.one) grid.TakeDataByIndex(currentSlot.x, currentSlot.y);
                currentSlot = index;
            }
            item.MoveTo(lastPos);

        }
        else
        {
            if (currentSlot != -Vector2Int.one) grid.TakeDataByIndex(currentSlot.x, currentSlot.y);
            currentSlot = -Vector2Int.one;
            lastPos = transformPos.position;
        }
    }
    
    private void OnDrawGizmos()
    {
        if(grid!=null)
        grid.DrawGrid();
    }

}
